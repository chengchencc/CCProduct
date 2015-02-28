using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.NetworkInformation;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class MainViewModel : BindableBase
    {
       private AboutViewModel _aboutModel;
       private DetailViewModel _detailModel;
       private ListLayoutsViewModel _listLayoutsModel;
       private DatasourcesViewModel _datasourcesModel;
       private ActionsViewModel _actionsModel;
        private PrivacyViewModel _privacyModel;

        private ViewModelBase _selectedItem = null;

        public MainViewModel()
        {
            _selectedItem = AboutModel;
            _privacyModel = new PrivacyViewModel();

        }
 
        public AboutViewModel AboutModel
        {
            get { return _aboutModel ?? (_aboutModel = new AboutViewModel()); }
        }
 
        public DetailViewModel DetailModel
        {
            get { return _detailModel ?? (_detailModel = new DetailViewModel()); }
        }
 
        public ListLayoutsViewModel ListLayoutsModel
        {
            get { return _listLayoutsModel ?? (_listLayoutsModel = new ListLayoutsViewModel()); }
        }
 
        public DatasourcesViewModel DatasourcesModel
        {
            get { return _datasourcesModel ?? (_datasourcesModel = new DatasourcesViewModel()); }
        }
 
        public ActionsViewModel ActionsModel
        {
            get { return _actionsModel ?? (_actionsModel = new ActionsViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            AboutModel.ViewType = viewType;
            DetailModel.ViewType = viewType;
            ListLayoutsModel.ViewType = viewType;
            DatasourcesModel.ViewType = viewType;
            ActionsModel.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public Visibility AppBarVisibility
        {
            get
            {
                return SelectedItem == null ? AboutVisibility : SelectedItem.AppBarVisibility;
            }
        }

        public Visibility AboutVisibility
        {

         get { return Visibility.Visible; }
        }

        public void UpdateAppBar()
        {
            OnPropertyChanged("AppBarVisibility");
            OnPropertyChanged("AboutVisibility");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadDataAsync(bool forceRefresh = false)
        {
            var loadTasks = new Task[]
            { 
                AboutModel.LoadItemsAsync(forceRefresh),
                DetailModel.LoadItemsAsync(forceRefresh),
                ListLayoutsModel.LoadItemsAsync(forceRefresh),
                DatasourcesModel.LoadItemsAsync(forceRefresh),
                ActionsModel.LoadItemsAsync(forceRefresh),
            };
            await Task.WhenAll(loadTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand RefreshCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await LoadDataAsync(true);
                });
            }
        }

        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand PrivacyCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateTo(_privacyModel.Url);
                });
            }
        }
    }
}
