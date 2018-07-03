using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs.Builders
{
    public class RichCardAttachmentBuilder
    {
        private static IList<Attachment> GetCardsAttachments()
        {
            return new List<Attachment>()
            {
                GetHeroCard(
                    "Azure Functions",
                    "Process events with a serverless code architecture",
                    new CardAction(ActionTypes.PostBack, "Learn more", value: "https://azure.microsoft.com/en-us/services/functions/")),
            };
        }

        private static Attachment GetHeroCard(string title, string text, CardAction cardAction)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Text = text,
                Buttons = new List<CardAction>() { cardAction },
            };

            return heroCard.ToAttachment();
        }

        private static Attachment GetThumbnailCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
        {
            var heroCard = new ThumbnailCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Images = new List<CardImage>() { cardImage },
                Buttons = new List<CardAction>() { cardAction },
            };

            return heroCard.ToAttachment();
        }
    }
}