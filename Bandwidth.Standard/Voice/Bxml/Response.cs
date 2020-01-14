using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Bandwidth.Standard.Voice.Bxml
{
  /// <summary>
  ///   Response class for Bandwidth XML
  /// </summary>
  [XmlRoot(Namespace = "")]
  public class Response : IXmlSerializable
  {
    private static readonly XmlSerializer Serializer = new XmlSerializer(typeof (Response), "");
    private readonly List<IVerb> _list = new List<IVerb>();

        private static readonly Regex XML_REGEX = new Regex("&lt;([a-zA-Z//].*?)&gt;");

        private static readonly Regex SPEAK_SENTENCE_REGEX = new Regex("<SpeakSentence.*?>.*?<\\/SpeakSentence>");

        /// <summary>
        ///   Default constructor
        /// </summary>
        public Response()
    {
    }

    /// <summary>
    ///   Constructor with verbs
    /// </summary>
    /// <param name="verbs">verbs to be added to response</param>
    public Response(params IVerb[] verbs)
    {
      _list.AddRange(verbs);
    }

    XmlSchema IXmlSerializable.GetSchema() => null;

    void IXmlSerializable.ReadXml(XmlReader reader)
    {
      throw new NotImplementedException();
    }

    void IXmlSerializable.WriteXml(XmlWriter writer)
    {
      var ns = new XmlSerializerNamespaces();
      ns.Add("", "");
      foreach (var verb in _list)
      {
        var serializer = new XmlSerializer(verb.GetType(), "");
        serializer.Serialize(writer, verb, ns);
      }
    }

    /// <summary>
    ///   Add new verb to response
    /// </summary>
    /// <param name="verb">verb instance</param>
    public void Add(IVerb verb)
    {
      _list.Add(verb);
    }



        /// <summary>
        ///   Returns BXML for response without escaped SSML
        /// </summary>
        /// <returns>Generated XML string</returns>
        public string ToBXML()
        {

            string str = "";
            using (var writer = new Utf8StringWriter { NewLine = "" })
            {
                Serializer.Serialize(writer, this);
                str =  writer.ToString();
            }

            MatchEvaluator matchEvaluator = new MatchEvaluator(match => 
                XML_REGEX.Replace(match.Value, "<$1>")
            );

            return SPEAK_SENTENCE_REGEX.Replace(str, matchEvaluator);
        }

        private class Utf8StringWriter : StringWriter
    {
      public override Encoding Encoding => Encoding.UTF8;
    }
  }
}
