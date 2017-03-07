// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LuisModel.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN YUAN. All rights reserved.
// </copyright>
// </copyright>
// <summary>
//   Defines the LuisModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BotApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The luis model.
    /// </summary>
    public class CustomLuisModel
    {
        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        public string query { get; set; }

        public TopScoringIntentType topScoringIntentType { get; set; }

        public  IntentMdel[] intents{ get; set; }

        public  EntityModel[] entities { get; set; }

        /// <summary>
        /// The top scoring intent type.
        /// </summary>
        public class TopScoringIntentType
        {
            public string intent { get; set; }

            public float score { get; set; }
        }

        public class IntentMdel
        {
            public string Intent { get; set; }

            public float score { get; set; }
        }


        public class EntityModel
        {
            public string entity { get; set; }

            public string type { get; set; }

            public int startInde { get; set; }

            public int endIndex { get; set; }

            public float score { get; set; }
        }
    }
}