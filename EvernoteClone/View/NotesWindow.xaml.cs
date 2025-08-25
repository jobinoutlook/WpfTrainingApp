using EvernoteClone.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EvernoteClone.View
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        NotesVM viewModel;
        public NotesWindow()
        {
            InitializeComponent();

            viewModel = Resources["nvm"] as NotesVM;
            viewModel.SelectedNoteChanged += ViewModel_SelectedNoteChanged;

            var fontFamilies = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cbxFontFamily.ItemsSource = fontFamilies;

            List<double> fontSizes = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 28, 48, 72 };
            cbxFontSize.ItemsSource = fontSizes;

        }

        private void ViewModel_SelectedNoteChanged(object? sender, EventArgs e)
        {
            rtxbNoteContent.Document.Blocks.Clear();
            if (viewModel.SelectedNote != null)
            {
                if (!string.IsNullOrEmpty(viewModel.SelectedNote.FileLocation))
                {
                    FileStream fileStream = new FileStream(viewModel.SelectedNote.FileLocation, FileMode.Open);
                    var contents = new TextRange(rtxbNoteContent.Document.ContentStart, rtxbNoteContent.Document.ContentEnd);
                    contents.Load(fileStream, DataFormats.Rtf);
                    fileStream.Close();
                }
                
            }
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void rtxbNoteContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            int amountCharecters = (new TextRange(rtxbNoteContent.Document.ContentStart,rtxbNoteContent.Document.ContentEnd)).Text.Length;
            txbStatus.Text = $"Document length: {amountCharecters} characters";
        }

        private void btnBold_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonChecked = (sender as ToggleButton).IsChecked ?? false;

            if (isButtonChecked)
                rtxbNoteContent.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
            else
                rtxbNoteContent.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
        }

        private void rtxbNoteContent_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedFontWeight = rtxbNoteContent.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (selectedFontWeight != DependencyProperty.UnsetValue) && (selectedFontWeight.Equals(FontWeights.Bold));

            var selectedFontStyle = rtxbNoteContent.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (selectedFontStyle != DependencyProperty.UnsetValue) && (selectedFontStyle.Equals(FontStyles.Italic));

            var selectedTextDecoration = rtxbNoteContent.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (selectedTextDecoration != DependencyProperty.UnsetValue) && (selectedTextDecoration.Equals(TextDecorations.Underline));

            cbxFontFamily.SelectedItem = rtxbNoteContent.Selection.GetPropertyValue(Inline.FontFamilyProperty);

            cbxFontSize.Text = (rtxbNoteContent.Selection.GetPropertyValue(Inline.FontSizeProperty)).ToString();
        }

        private void btnItalic_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonChecked = (sender as ToggleButton).IsChecked ?? false;

            if (isButtonChecked)
                rtxbNoteContent.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);
            else
                rtxbNoteContent.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);
        }

        private void btnUnderline_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonEnabled = (sender as ToggleButton).IsChecked ?? false;

            if (isButtonEnabled)
                rtxbNoteContent.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            else
            {
                TextDecorationCollection textDecorations;
                (rtxbNoteContent.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection).TryRemove(TextDecorations.Underline, out textDecorations);
                rtxbNoteContent.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, textDecorations);
            }

        }

        private void cbxFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxFontFamily.SelectedItem != null)
            {
                rtxbNoteContent.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cbxFontFamily.SelectedItem);
            }
        }

        private void cbxFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            rtxbNoteContent.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cbxFontSize.SelectedItem);
        }

        private void btnSaveNote_Click(object sender, RoutedEventArgs e)
        {
            string rtfFile = System.IO.Path.Combine(Environment.CurrentDirectory, $"{viewModel.SelectedNote.Id}.rtf");
            viewModel.SelectedNote.FileLocation = rtfFile;
            DatabaseHelper.Update(viewModel.SelectedNote);

            FileStream fileStream = new FileStream(rtfFile, FileMode.Create);
            var contents = new TextRange(rtxbNoteContent.Document.ContentStart, rtxbNoteContent.Document.ContentEnd);
            contents.Save(fileStream, DataFormats.Rtf);
            
            fileStream.Close();
        }
    }
}
