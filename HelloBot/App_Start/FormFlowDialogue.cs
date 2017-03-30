using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;

namespace HelloBot
{
    public enum StatusOptions
    {
        Did, WillDo, Problems
    };
    //public String DidStatus {  };
    //public String WillDoStatus {  };
    //public String ProblemsStatus {  };

    [Serializable]
    public class CompleteStatus
    {
        public StatusOptions? StatusOptions;
        //public DidStatus? Done;
        //public WillDoStatus? WillDo;
        //public ProblemsStatus? Problems;

        public static IForm<CompleteStatus> BuildForm()
        {
            return new FormBuilder<CompleteStatus>()
                    .Message("Welcome to the simple Status writing Daphne bot!")
                    .Build();
        }
    };
}