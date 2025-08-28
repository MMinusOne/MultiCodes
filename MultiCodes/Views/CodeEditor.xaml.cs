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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ICSharpCode.AvalonEdit.Highlighting;
using MultiCodes.Lib.Models;
using MultiCodes.ViewModels;

namespace MultiCodes.Views
{
    /// <summary>
    /// Interaction logic for CodeEditor.xaml
    /// </summary>
    public partial class CodeEditor : UserControl
    {
        public CodeEditor()
        {
            InitializeComponent();
            FileBarViewModel.Instance.OnNew((string text) =>
            {
                switch (FileBarViewModel.Instance.SelectedItemNode.ItemNodeType)
                {
                    case ItemType.CSharp:
                        TextEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");
                        break;

                    case ItemType.JavaScript:
                        TextEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("JS");
                        break;
                    case ItemType.CSS:
                        TextEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("CSS");
                        break;
                    case ItemType.HTML:
                        TextEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("HTML");
                        break;
                    case ItemType.TypeScript:
                        TextEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("TS");
                        break;

                    case ItemType.Rust:
                        TextEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("RS");
                        break;

                    case ItemType.C:
                        TextEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C");
                        break;

                    case ItemType.Cpp:
                        TextEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("CPP");
                        break;
                }
                TextEditor.Text = text;
                return true;
            });
        }

        private void TextEditor_TextChanged(object sender, EventArgs e)
        {
            CodeEditorViewModel.Instance.Code = TextEditor.Text;
        }
    }
}
