using System.ComponentModel;
using System.Xml.Serialization;

namespace Bandwidth.Standard.Voice.Bxml
{
  /// <summary>
  ///   The ResumeRecording verb is used to resume a recording that was previously paused by a <PauseRecording> verb.
  ///   Audio that occurs between a <PauseRecording> verb and a <ResumeRecording> verb will not be present in the recording.
  ///   The paused period will not be included in the duration of the recording and therefore will not contribute to the recording portion of the bill.
  ///   If there is not an ongoing recording at the time of this verb's execution, it has no effect.
  /// </summary>
  /// <seealso href="https://dev.bandwidth.com/voice/bxml/verbs/StopRecording.html" />
  public class ResumeRecording : IVerb
  {

   
  }
}
