﻿using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Models
{
    public class UserTimeout
    {
        /// <summary>Channel that had timeout event.</summary>
        public string Channel;

        /// <summary>Duration of timeout IN SECONDS.</summary>
        public int TimeoutDuration;

        /// <summary>Reason for timeout, if it was provided.</summary>
        public string TimeoutReason;

        /// <summary>Viewer that was timed out.</summary>
        public string Username;

        /// <summary>Id of Viewer that was timed out.</summary>
        public string TargetUserId;

        public UserTimeout(IrcMessage ircMessage)
        {
            Channel = ircMessage.Channel;
            Username = ircMessage.Message;

            foreach (var tag in ircMessage.Tags.Keys)
            {
                var tagValue = ircMessage.Tags[tag];

                switch (tag)
                {
                    case Tags.BanDuration:
                        TimeoutDuration = int.Parse(tagValue);
                        break;
                    case Tags.BanReason:
                        TimeoutReason = tagValue;
                        break;
                    case Tags.TargetUserId:
                        TargetUserId = tagValue;
                        break;
                }
            }
        }

        public UserTimeout(
            string channel,
            string username,
            string targetuserId,
            int timeoutDuration,
            string timeoutReason)
        {
            Channel = channel;
            Username = username;
            TargetUserId = targetuserId;
            TimeoutDuration = timeoutDuration;
            TimeoutReason = timeoutReason;
        }
    }
}
