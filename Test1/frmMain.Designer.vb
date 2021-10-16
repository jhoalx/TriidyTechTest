<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbServiceQuery = New System.Windows.Forms.GroupBox()
        Me.btnQueryService = New System.Windows.Forms.Button()
        Me.txtProductId = New System.Windows.Forms.TextBox()
        Me.lblProductId = New System.Windows.Forms.Label()
        Me.gbResults = New System.Windows.Forms.GroupBox()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.gbServiceQuery.SuspendLayout()
        Me.gbResults.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbServiceQuery
        '
        Me.gbServiceQuery.Controls.Add(Me.btnQueryService)
        Me.gbServiceQuery.Controls.Add(Me.txtProductId)
        Me.gbServiceQuery.Controls.Add(Me.lblProductId)
        Me.gbServiceQuery.Location = New System.Drawing.Point(13, 13)
        Me.gbServiceQuery.Name = "gbServiceQuery"
        Me.gbServiceQuery.Size = New System.Drawing.Size(212, 91)
        Me.gbServiceQuery.TabIndex = 0
        Me.gbServiceQuery.TabStop = False
        Me.gbServiceQuery.Text = "Service Query"
        '
        'btnQueryService
        '
        Me.btnQueryService.Location = New System.Drawing.Point(124, 49)
        Me.btnQueryService.Name = "btnQueryService"
        Me.btnQueryService.Size = New System.Drawing.Size(75, 23)
        Me.btnQueryService.TabIndex = 2
        Me.btnQueryService.Text = "Query"
        Me.btnQueryService.UseVisualStyleBackColor = True
        '
        'txtProductId
        '
        Me.txtProductId.Location = New System.Drawing.Point(18, 49)
        Me.txtProductId.Name = "txtProductId"
        Me.txtProductId.Size = New System.Drawing.Size(100, 23)
        Me.txtProductId.TabIndex = 1
        Me.txtProductId.Text = "8"
        '
        'lblProductId
        '
        Me.lblProductId.AutoSize = True
        Me.lblProductId.Location = New System.Drawing.Point(18, 30)
        Me.lblProductId.Name = "lblProductId"
        Me.lblProductId.Size = New System.Drawing.Size(63, 15)
        Me.lblProductId.TabIndex = 0
        Me.lblProductId.Text = "Product ID"
        '
        'gbResults
        '
        Me.gbResults.Controls.Add(Me.lblResult)
        Me.gbResults.Location = New System.Drawing.Point(13, 111)
        Me.gbResults.Name = "gbResults"
        Me.gbResults.Size = New System.Drawing.Size(212, 54)
        Me.gbResults.TabIndex = 1
        Me.gbResults.TabStop = False
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Font = New System.Drawing.Font("ProFontIIx NF", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblResult.Location = New System.Drawing.Point(52, 17)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(110, 26)
        Me.lblResult.TabIndex = 0
        Me.lblResult.Text = "NO INFO"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(243, 189)
        Me.Controls.Add(Me.gbResults)
        Me.Controls.Add(Me.gbServiceQuery)
        Me.Name = "frmMain"
        Me.Text = "Triidy Tech Test 1"
        Me.gbServiceQuery.ResumeLayout(False)
        Me.gbServiceQuery.PerformLayout()
        Me.gbResults.ResumeLayout(False)
        Me.gbResults.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbServiceQuery As GroupBox
    Friend WithEvents btnQueryService As Button
    Friend WithEvents txtProductId As TextBox
    Friend WithEvents lblProductId As Label
    Friend WithEvents gbResults As GroupBox
    Friend WithEvents lblResult As Label
End Class
