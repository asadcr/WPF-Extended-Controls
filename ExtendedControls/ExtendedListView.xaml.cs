using ExtendedControls.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ExtendedControls
{
    /// <summary>
    /// Interaction logic for ExtendedListView.xaml
    /// </summary>
    public partial class ExtendedListView : UserControl
    {
        private CollectionViewSource view = new CollectionViewSource();
        private List<EmailViewModel> _Emails = new List<EmailViewModel>();
        private int _CurrentPageIndex = 0;
        private int _ItemsPerPage = 100;
        private int _TotalPages = 0;
        private int _EmailsCount = 0;

        public ExtendedListView()
        {
            InitializeComponent();
            this.DataContext = this;
            ListViewEmails.SelectionChanged += ListViewEmails_SelectionChanged;
        }

        private void ListViewEmails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
                OnSelectedEmailChanged?.Invoke(e.AddedItems[0] as EmailViewModel);
            else
                OnSelectedEmailChanged?.Invoke(new EmailViewModel { Attachments = new List<AttachmentViewModel>() , Body = " " , Subject = "", To = "", From = "" , EmailID = "", HasAttachment = false , Checked = false , Type = 0 });
        }

        public List<EmailViewModel> Emails
        {
            get
            {
                return view.Source as List<EmailViewModel>;
            }
            set
            {
                view.Source = value;
                _Emails = value;
                EmailsCount = value.Count;
                view.Filter += view_Filter;
                ListViewEmails.DataContext = view;
            }
        }
        
        public void AddEmails(List<EmailViewModel> model)
        {
            this.Dispatcher.Invoke(() =>
            {
                Emails = Emails.Concat(model).ToList();
            });
        }

        public int EmailsCount
        {
            get
            {
                return _EmailsCount;
            }
            set
            {
                _EmailsCount = value;
                _TotalPages = _EmailsCount / _ItemsPerPage;
                if (_EmailsCount % _ItemsPerPage != 0)
                    _TotalPages += 1;
                tbTotalPage.Text = _TotalPages.ToString();
            }
        }

        public string txtSearchTitle
        {
            set
            {
                txtFilter.Prompt = value;
            }
        }

        public string NoResultTitle
        {
            get
            {
                return txtnoresults.Text;
            }
            set
            {
                txtnoresults.Text = value;
            }
        }
        public string btnFirstTitle
        {
            set
            {
                btnFirst.Content = value;
            }
        }
        public string btnPrevTitle
        {
            set
            {
                btnPrev.Content = value;
            }
        }
        public string btnNextTitle
        {
            set
            {
                btnNext.Content = value;
            }
        }
        public string btnLastTitle
        {
            set
            {
                btnLast.Content = value;
            }
        }

        public event Action<EmailViewModel> OnSelectedEmailChanged;

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilter.Text))
                _Emails = Emails.Where(a => a.From.IndexOf(txtFilter.Text,StringComparison.InvariantCultureIgnoreCase) >= 0 || 
                                            a.To.IndexOf(txtFilter.Text, StringComparison.InvariantCultureIgnoreCase) >= 0 || 
                                            a.Subject.IndexOf(txtFilter.Text, StringComparison.InvariantCultureIgnoreCase) >= 0 ).ToList();
            else
                _Emails = Emails;
            txtnoresults.Visibility = _Emails.Count == 0 ? Visibility.Visible : Visibility.Collapsed;

            if (_Emails.Count == 0)
                ListViewEmails.SelectedIndex = -1;
            view.View.Refresh();
        }

        private void view_Filter(object sender, FilterEventArgs e)
        {
            int index = _Emails.IndexOf((EmailViewModel)e.Item);
            if (index >= _ItemsPerPage * _CurrentPageIndex && index < _ItemsPerPage * (_CurrentPageIndex + 1))
            {
                e.Accepted = true;                
            }
            else
            {
                e.Accepted = false;
            }
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            if (_CurrentPageIndex != 0)
            {
                _CurrentPageIndex = 0;
                UpdateCurrentPage();
            }
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (_CurrentPageIndex > 0)
            {
                _CurrentPageIndex -= 1;
                UpdateCurrentPage();
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (_CurrentPageIndex < _TotalPages - 1)
            {
                _CurrentPageIndex += 1;
                UpdateCurrentPage();
            }
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            // Display the last page  
            if (_CurrentPageIndex != _TotalPages - 1)
            {
                _CurrentPageIndex = _TotalPages - 1;
                UpdateCurrentPage();
            }
        }

        private void UpdateCurrentPage()
        {
            view.View.Refresh();
            tbCurrentPage.Text = (_CurrentPageIndex + 1).ToString();
        }
    }
}
