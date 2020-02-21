using System.Linq;
using RobSharper.Ros.MessageParser;
using RobSharper.Ros.MessageParser.Tests.Helpers;
using Xunit;

namespace RobSharper.Ros.MessageParser.Tests
{
    public class ActionParserTests
    {
        [Fact]
        public void Can_parse_empty_action()
        {
            var message = "---\n---";

            var parser = new ActionParser(message);
            var actual = parser.Parse();

            Assert.NotNull(actual);
            Assert.NotNull(actual.Goal);
            Assert.NotNull(actual.Feedback);
            Assert.NotNull(actual.Result);

            Assert.True(actual.Goal.IsEmpty);
            Assert.True(actual.Feedback.IsEmpty);
            Assert.True(actual.Result.IsEmpty);
        }

        [Theory]
        [TestMessages("*.action")]
        public void Can_load_action_file(TestMessage file)
        {
            var parser = new ActionParser(file.Content.Value);
            var actual = parser.Parse();
            
            Assert.NotNull(actual);
        }

        [Fact]
        public void Goal_result_and_feedback_messages_are_parsed()
        {
            var followJointTrajectoryAction = TestMessageHelper.GetActionFile("control_msgs", "FollowJointTrajectory");
            
            var parser = new ActionParser(followJointTrajectoryAction.Content.Value);
            var actual = parser.Parse();
            
            Assert.NotNull(actual);

            var goalMessage = actual.Goal;
            goalMessage.AssertThat().FieldNameExists("trajectory");
            goalMessage.AssertThat().FieldNameExists("path_tolerance");
            goalMessage.AssertThat().FieldNameExists("goal_tolerance");
            goalMessage.AssertThat().FieldNameExists("goal_time_tolerance");

            var resultMessage = actual.Result;
            resultMessage.AssertThat().FieldNameExists("error_code");
            resultMessage.AssertThat().FieldNameExists("error_string");
            resultMessage.AssertThat().ConstantNameExists("SUCCESSFUL");
            resultMessage.AssertThat().ConstantNameExists("INVALID_GOAL");
            resultMessage.AssertThat().ConstantNameExists("INVALID_JOINTS");
            resultMessage.AssertThat().ConstantNameExists("OLD_HEADER_TIMESTAMP");
            resultMessage.AssertThat().ConstantNameExists("PATH_TOLERANCE_VIOLATED");
            resultMessage.AssertThat().ConstantNameExists("GOAL_TOLERANCE_VIOLATED");

            var feedbackMessage = actual.Feedback;
            feedbackMessage.AssertThat().FieldNameExists("joint_names");
            feedbackMessage.AssertThat().FieldNameExists("desired");
            feedbackMessage.AssertThat().FieldNameExists("actual");
            feedbackMessage.AssertThat().FieldNameExists("error");
        }
    }
}