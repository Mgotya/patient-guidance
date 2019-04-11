using System.Collections.Generic;
using System.Linq;
using PatientGuidance.App.Common;
using PatientGuidance.App.ViewModels;
using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;

namespace PatientGuidance.App.Views
{
    public partial class StateContainerPage : ContentPage
    {

        private StateContainerPageViewModel _ctx;

        public StateContainerPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if (BindingContext is StateContainerPageViewModel ctx)
            {
                _ctx = ctx;
                ctx.OnReady = Loaded;
            }
        }

        private void Loaded()
        {
            var tabView = new SfTabView();
            var tabItems = new TabItemCollection();
            foreach (var c in _ctx.Cards)
            {
                switch (c.Type)
                {
                    case CardType.Default:
                        tabItems.Add(new SfTabItem
                        {
                            Title = c.Title,
                            Content = CreateDeafultTemplate(c)
                        });
                        break;
                    case CardType.GastroQuestions:
                        tabItems.Add(new SfTabItem
                        {
                            Title = c.Title,
                            Content = CreateGastroQuestion(c)
                        });
                        break;
                    case CardType.GastroYesNo:
                        tabItems.Add(new SfTabItem
                        {
                            Title = c.Title,
                            Content = CreateYesNoTemplate(c)
                        });
                        break;
                    case CardType.GastroTimeLine:
                        tabItems.Add(new SfTabItem
                        {
                            Title = c.Title,
                            Content = CreateTimeLineTemplate(c)
                        });
                        break;
                }
            }

            tabItems.Add(new SfTabItem
            {
                Title = "סיום",
                Content = LastStep()
            });
            tabView.Items = tabItems;
            this.Content = tabView;
            
        }

        private Grid CreateTimeLineTemplate(Card card)
        {
            var container = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Star},
                    new RowDefinition {Height = GridLength.Auto},
                }
            };
            var stack = new StackLayout();
            stack.Children.Add(new Label
            {
                Text = "איזה חומר הכנה קיבלת מהרופא המשפחה:"
            });
            var segmentedControl = new SfSegmentedControl
            {
                SelectionTextColor = Color.White,
                HeightRequest = 80,
                Color = Color.Transparent,
                BorderColor = Color.FromHex("#929292"),
                FontColor = Color.FromHex("#929292"),
                SelectedIndex = 0,
                BackgroundColor = Color.Transparent,
                VisibleSegmentsCount = 3,
                DisplayMode = SegmentDisplayMode.Text,
                Margin = 10
            };
            List<string> list = new List<string>
            {
                "פיקולקס","מרוקן","אחר"
            };
            segmentedControl.ItemsSource = list;
            stack.Children.Add(segmentedControl);
            container.Children.Add(stack,0,0);

            var st = new StackLayout
            {
                Margin = new Thickness(0, 10, 50, 0)
            };

            foreach (var cardQuestion in card.Questions)
            {
                
                st.Children.Add(new Label
                {
                    Text = cardQuestion.Key,
                    HorizontalOptions = LayoutOptions.End,
                    FontSize = 25
                });

                foreach (var lbl in cardQuestion.Value)
                {
                    st.Children.Add(new Label
                    {
                        Text = lbl,
                        FontSize = 15,
                        Margin = new Thickness(0,0,10,0)
                    });
                }
            }

            container.Children.Add(st,0,1);

            container.Children.Add(new SfButton
            {
                Text = "היתה לי יציאה",
                Margin = 10,
                BackgroundColor = Color.CornflowerBlue
            },0,2);

            return container;
        }

        private Grid CreateYesNoTemplate(Card card)
        {
            var container = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition {Height = GridLength.Star},
                    new RowDefinition {Height = GridLength.Star},
                }
            };

            var stack = new StackLayout
            {
                Margin = new Thickness(10,10,50,0)
            };
            stack.Children.Add(new Label
            {
                Text = card.Questions.First().Key,
                FontSize = 20
            });
            foreach (var lbl in card.Questions.First().Value)
            {
                stack.Children.Add(new Label
                {
                    Text = lbl,
                    FontSize = 15,
                    Margin = new Thickness(0,0,20,0),
                    TextColor = Color.ForestGreen
                });
            }

            var stack1 = new StackLayout
            {
                Margin = new Thickness(10, 10, 50, 0)
            };
            stack1.Children.Add(new Label
            {
                Text = card.Questions.Last().Key,
                FontSize = 20
            });
            foreach (var lbl in card.Questions.Last().Value)
            {
                stack1.Children.Add(new Label
                {
                    Text = lbl,
                    FontSize = 15,
                    Margin = new Thickness(0, 0, 20, 0),
                    TextColor = Color.DarkRed
                });
            }

            container.Children.Add(stack,0,0);
            container.Children.Add(stack1,0,1);
            return container;
        }

        private Grid LastStep()
        {
            var lastone = new Grid
            {
                Margin = 10,
            };
            lastone.Children.Add(new SfButton
            {
                Text = "יציאה",
                Command = _ctx.CompleateCommand,
                BackgroundColor = Color.CornflowerBlue,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End,
                Margin = 10,
                WidthRequest = 100
            });
            return lastone;
        }

        private Grid CreateGastroQuestion(Card card)
        {
            var container = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition {Height = GridLength.Star},
                    new RowDefinition {Height = GridLength.Star},
                    new RowDefinition {Height = 200},
                }
            };
            var stack = new StackLayout
            {
                Margin = new Thickness(0,10,50,0),
            };
            stack.Children.Add(new Label
            {
                Text = card.Questions.First().Key,
                FontSize = 18
            });
            stack.Children.Add(new Label
            {
                Text = card.Questions.First().Value[0],
                FontSize = 12,
                Margin = new Thickness(0, 0, 20, 0)
            });
            stack.Children.Add(new Label
            {
                Text = card.Questions.First().Value[1],
                FontSize = 12,
                Margin = new Thickness(0,0,20,0)
            });

            container.Children.Add(stack,0,0);

            var stack1 = new StackLayout
            {
                Margin = new Thickness(0, 10, 50, 0),
            };
            stack1.Children.Add(new Label
            {
                Text = card.Questions.Last().Key,
                FontSize = 18
            });
            stack1.Children.Add(new Label
            {
                Text = card.Questions.Last().Value[0],
                FontSize = 12,
                Margin = new Thickness(0, 0, 20, 0)
            });
            stack1.Children.Add(new Label
            {
                Text = card.Questions.Last().Value[1],
                FontSize = 12,
                Margin = new Thickness(0, 0, 20, 0)
            });

            container.Children.Add(stack1,0,1);

            container.Children.Add(new Label
            {
                Text = card.SubContent,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            },0,2);

            return container;
        }

        private static Grid CreateDeafultTemplate(Card c)
        {
            Grid container = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition {Height = GridLength.Auto}, new RowDefinition {Height = GridLength.Star}
                }
            };

            container.Children.Add(new Label
            {
                Text = c.Content,
                FontSize = 22,
                Margin = 20
            });

            var st = new StackLayout();
            foreach (var d in c.Questions)
            {
                st.Children.Add(new Label
                {
                    Text = d.Key,
                    FontSize = 19,
                    Margin = new Thickness(0,0,20,0)
                });

                foreach (var lbl in d.Value)
                {
                    st.Children.Add(new Label
                    {
                        Text = lbl,
                        FontSize = 14,
                        Margin = new Thickness(5,0,30,0)
                    });
                }
            }

            container.Children.Add(st,0,1);

            return container;
        }
    }
}
