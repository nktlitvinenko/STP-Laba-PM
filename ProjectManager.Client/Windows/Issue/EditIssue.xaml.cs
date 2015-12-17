using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjectManager.Client.ViewModels;

namespace ProjectManager.Client.Windows.Issue
{
    /// <summary>
    /// Interaction logic for EditIssue.xaml
    /// </summary>
    public partial class EditIssue : Window
    {
        public EditIssue(Guid projectId)
        {
            InitializeComponent();
            tbProjectId.Text = projectId.ToString();
            ((EditIssueViewModel) DataContext).ProjectId = projectId.ToString();
        }
    }
}
