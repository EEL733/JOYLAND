using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace JOYLAND.Behavior {
    public class NumberTextBoxBehaviorBase : Behavior<TextBox> {
        protected override void OnAttached() {
            base.OnAttached();
            AssociatedObject.PreviewTextInput += AssociatedObject_PreviewTextInput;
            DataObject.AddPastingHandler(AssociatedObject, AssociatedObject_PastingHandler);
        }

        protected override void OnDetaching() {
            base.OnDetaching();
            AssociatedObject.PreviewTextInput -= AssociatedObject_PreviewTextInput;
            DataObject.RemovePastingHandler(AssociatedObject, AssociatedObject_PastingHandler);
        }

        internal virtual bool CanInput(string text) {
            return !text.Any(c => !char.IsNumber(c));
        }

        private void AssociatedObject_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e) {
            if (!CanInput(GetNewString((TextBox)sender, e.Text))) {
                e.Handled = true;
            }
        }

        private void AssociatedObject_PastingHandler(object sender, DataObjectPastingEventArgs e) {
            if (e.DataObject.GetDataPresent(DataFormats.Text)) {
                string text = Convert.ToString(e.DataObject.GetData(DataFormats.Text));
                if (!CanInput(GetNewString((TextBox)sender, text))) {
                    e.CancelCommand();
                }
            } else {
                e.CancelCommand();
            }
        }

        private string GetNewString(TextBox textBox, string input) {
            string pre = textBox.Text;
            int selectionStart = textBox.SelectionStart;
            int selectionLength = textBox.SelectionLength;
            return pre.Remove(selectionStart, selectionLength).Insert(selectionStart, input);
        }
    }

    public class DeclaredScoreTextBoxBehavior : NumberTextBoxBehaviorBase {
        internal override bool CanInput(string text) {
            if(!base.CanInput(text)) {
                return false;
            }

            int score = int.Parse(text);
            return 0 <= score && score <= 1000;
        }
    }

    public class ActualScoreTextBoxBehavior : NumberTextBoxBehaviorBase {
        internal override bool CanInput(string text) {
            if (!base.CanInput(text)) {
                return false;
            }

            int score = int.Parse(text);
            return 0 <= score && score <= 10000000;
        }
    }

    public class DetailInputWindowTextBoxBehavior : NumberTextBoxBehaviorBase {
        internal override bool CanInput(string text) {
            Regex regex = new Regex("^[0-9]{0,4}$");
            return regex.IsMatch(text);
        }
    }
}
