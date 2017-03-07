// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultDialog.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the DefaultDialog type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BotApp.Models
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Builder.Luis;
    using Microsoft.Bot.Builder.Luis.Models;

    /// <summary>
    /// The default dialog.
    /// </summary>
    [LuisModel("WallELuis", "029649524cea4917b39956be2648890c")]
    [Serializable]
    public class DefaultDialog : LuisDialog<CustomLuisModel>
    {
        /// <summary>
        /// The none.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry, I dont know what you wanted");
            context.Wait(this.MessageReceived);
        }

        /// <summary>
        /// The ask about author.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [LuisIntent("Ask about author")]
        public async Task AskAboutAuthor(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("You want to know about the author");
            context.Wait(this.MessageReceived);
        }

        /// <summary>
        /// The contact author.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [LuisIntent("Contact the author")]
        public async Task ContactAuthor(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("You want to contact the author");
            context.Wait(this.MessageReceived);
        }
    }
}