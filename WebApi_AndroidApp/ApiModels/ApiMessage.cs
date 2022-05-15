using WebApi_AndroidApp.Models;

namespace WebApi_AndroidApp.ApiModels
{
    public class ApiMessage
    {


        public ApiMessage(MessageItem message, RockPaperScissor _context)
        {
            MessageID = message.MessageID ?? 0L;
            FromUser = message.FromUserID;
            ToUser = message.ToUserID;
            Value = message.Value;
            Sent = message.TimeSent;

            FromUserFirstName = _context.User.First(x => x.UserID == FromUser).FirstName;
            FromUserLastName = _context.User.First(x => x.UserID == FromUser).LastName;
        }

        public long MessageID { get; set; }

        public long FromUser { get; set; }
        public long ToUser { get; set; }
        public string Value { get; set; } = string.Empty;
        public DateTime Sent { get; set; }

        public string FromUserFirstName { get; set; } = "";
        public string FromUserLastName { get; set; } = "";
    }
}
