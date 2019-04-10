using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PatientGuidance.App.Common;
using PatientGuidance.App.Models;
using PatientGuidance.App.Services;
using Prism.Commands;
using Prism.Navigation;
using Syncfusion.DataSource.Extensions;

namespace PatientGuidance.App.ViewModels
{
	public class ColonoQuestionPageViewModel : ViewModelBase
	{
        private readonly IQuestionProvider _questionProvider;
        public ObservableCollection<QuestionViewModel> Questions { get; set; }

        public string NextLabel { get; set; } = "הבא";
        public DelegateCommand Next { get; set; }
        

        public ColonoQuestionPageViewModel(INavigationService navigationService, IQuestionProvider questionProvider) 
            : base(navigationService)
        {
            _questionProvider = questionProvider;
            Questions = new ObservableCollection<QuestionViewModel>();

            Next = new DelegateCommand(MoveToNextPage);
        }

        private async void MoveToNextPage()
        {
            Settings.IsSpecial = Questions.Any(q => q.IsYesAnswer);
            Settings.IsLogIn = true;
            await NavigationService.NavigateAsync("StateContainerPage");
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            var enumerable = await _questionProvider.GetGastroPrerequisiteQuestionsAsync();

            FunctionalExtensions.ToList<Question>(enumerable)
                .ForEach(q => Questions.Add(new QuestionViewModel(q)));
        }
    }


    public class QuestionViewModel
    {
        private readonly Question _question;
        public string Content => _question.Content;
        public bool IsYesAnswer { get; set; }

        public QuestionViewModel(Question question)
        {
            _question = question;
        }
    }
}
