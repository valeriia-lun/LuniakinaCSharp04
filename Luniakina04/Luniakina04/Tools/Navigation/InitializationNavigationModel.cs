using System;
using Luniakina04.Views;

namespace Luniakina04.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.TableView:
                    ViewsDictionary.Add(viewType, new TableView());
                    break;
                case ViewType.AddPersonView:
                    ViewsDictionary.Add(viewType, new AddingPersonView());
                    break;
                case ViewType.EditPersonView:
                    ViewsDictionary.Add(viewType, new EditingPersonView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
