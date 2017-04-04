using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;
using System.IO;
using System.Resources;

namespace HelloBot
{

    // TODO:
    // write the same IForm<CompleteStatus> BuildForm() for entity class which i will get from master 
    // and fill fields from entity(or some model class* optionally) - that`s getting questions from database
    // and save changes in database context in saveState function
    [Serializable]
    public class CompleteStatus
    { 
        public string Did { get; set; }
        public string WillDo { get; set; }
        public string Problems { get; set; }  
        public static IForm<CompleteStatus> BuildForm()
        {
            OnCompletionAsyncDelegate<CompleteStatus> saveState = async (context, state) =>
            {
                // to implement saving state to database:
                // add fields (state) to db context and save it
                await context.PostAsync("some message");
                // throw notimplementedexception
                
            };

            return new FormBuilder<CompleteStatus>()
                    .Message("Welcome to the simple Status writing Daphne bot!")
                    .OnCompletion(saveState)
                    .Build();
        }




    };
}