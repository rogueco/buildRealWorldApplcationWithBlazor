using Microsoft.AspNetCore.Components;

namespace BlazingShop.Pages.LearnBlazor
{
    public class LearnBlazorBase : ComponentBase
    {
        protected string Name = "Spark";
        protected string WelcomeText = "Time to learn Blazor!";

        protected void GetName()
        {
            Name = "Blazor Learner";
        }
    }
}