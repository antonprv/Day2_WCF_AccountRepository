// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.Windows.Forms;

namespace Client.Forms
{
  public partial class DeleteDialog : Form
  {
    public DeleteDialog()
    {
      InitializeComponent();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void ConfirmButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void DeleteDialog_FormClosed(object sender, FormClosedEventArgs e)
    {
      cancelButton.Click -= CancelButton_Click;
      confirmButton.Click -= ConfirmButton_Click;
    }
  }
}
