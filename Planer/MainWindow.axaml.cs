using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.LogicalTree;
using Avalonia.Media;

namespace Planer;

public class Task
{
    public String? Name;
    public String Category;
    public int CategoryIndex;
    public Boolean IsFinished;
        
    public Task(String? taskName, String taskCategory, Boolean isFinished, int taskCategoryIndex)
    {
        Name = taskName;
        Category = taskCategory;
        IsFinished = isFinished;
        CategoryIndex = taskCategoryIndex;
    }
}
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void SubmitInfoButton_Click(object sender, RoutedEventArgs e)
    {
        Task newTask = new(TextBox_TaskName.Text, ComboBox_Category?.SelectedItem.ToString(), false, ComboBox_Category.SelectedIndex);

        if (Panel_TaskGrid.Children.Count < 8)
        {
            if (newTask.Name == null)
            {
                newTask.Name = "Zadanie bez nazwy";
            }
        
            var taskName = new TextBlock
            {
                Text = newTask.Name, 
                HorizontalAlignment = HorizontalAlignment.Center
            };
            
            var taskCategory = new ComboBox
            {
                HorizontalAlignment = HorizontalAlignment.Center 
            };
            taskCategory.Items.Add(new TextBlock { Text = "--Wybierz--" });
            taskCategory.Items.Add(new TextBlock { Text = "Praca" });
            taskCategory.Items.Add(new TextBlock { Text = "Relaks" });
            taskCategory.Items.Add(new TextBlock { Text = "Zakupy" });
            taskCategory.SelectedIndex = newTask.CategoryIndex;
            
            var taskFinished = new CheckBox
            {
                IsChecked = newTask.IsFinished, 
                Content = "Zakończono", 
                HorizontalAlignment = HorizontalAlignment.Center
            };
            
            var taskDelete = new Button
            {
                Content = "Usuń", 
                HorizontalAlignment = HorizontalAlignment.Center
            };
            
            taskDelete.Click += (sender, args) =>
            {
                var button = (Button)sender;
                var stackPanel = (StackPanel)button.Parent;
                var border = (Border)stackPanel.Parent;
                
                Panel_TaskGrid.Children.Remove(border);
            };
            
            var taskElement = new StackPanel
            {
                Width = 180, 
                Height = 130
            };
            taskElement.Margin = new Thickness(10);
            taskElement.Children.Add(taskName);
            taskElement.Children.Add(taskCategory);
            taskElement.Children.Add(taskFinished);
            taskElement.Children.Add(taskDelete);
            
            var taskBorder = new Border
            {
                Width = 190 , 
                Height = 150, 
                BorderBrush = Brushes.DarkGray , 
                Background = Brushes.DarkGray
            };
            taskBorder.Margin = new Thickness(5);
            taskBorder.Child = taskElement;
            
            Panel_TaskGrid.Children.Add(taskBorder);
        }
    }
}