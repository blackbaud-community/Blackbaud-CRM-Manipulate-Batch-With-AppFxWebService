<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.cmdAddConstitBatch = New System.Windows.Forms.Button
        Me.txtBatchDescription = New System.Windows.Forms.TextBox
        Me.cboAddressTypeCodeID = New System.Windows.Forms.ComboBox
        Me.lblAddressType = New System.Windows.Forms.Label
        Me.lblCountry = New System.Windows.Forms.Label
        Me.cboCountryID = New System.Windows.Forms.ComboBox
        Me.txtAddressBlock = New System.Windows.Forms.TextBox
        Me.lblAddressBlock = New System.Windows.Forms.Label
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.lblCity = New System.Windows.Forms.Label
        Me.cboStateID = New System.Windows.Forms.ComboBox
        Me.lblStateID = New System.Windows.Forms.Label
        Me.lblPostCode = New System.Windows.Forms.Label
        Me.txtPostCode = New System.Windows.Forms.TextBox
        Me.cmdAddRowToBatch = New System.Windows.Forms.Button
        Me.cmdNewBatchRow = New System.Windows.Forms.Button
        Me.lblISOrganization = New System.Windows.Forms.Label
        Me.cboConstituentType = New System.Windows.Forms.ComboBox
        Me.lblKeyName = New System.Windows.Forms.Label
        Me.txtKeyName = New System.Windows.Forms.TextBox
        Me.cmdClearForm = New System.Windows.Forms.Button
        Me.lblBatchDescription = New System.Windows.Forms.Label
        Me.grpAddress = New System.Windows.Forms.GroupBox
        Me.grpAddress.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdAddConstitBatch
        '
        Me.cmdAddConstitBatch.Enabled = False
        Me.cmdAddConstitBatch.Location = New System.Drawing.Point(331, 34)
        Me.cmdAddConstitBatch.Name = "cmdAddConstitBatch"
        Me.cmdAddConstitBatch.Size = New System.Drawing.Size(119, 39)
        Me.cmdAddConstitBatch.TabIndex = 0
        Me.cmdAddConstitBatch.Text = "Create Constituent Batch"
        Me.cmdAddConstitBatch.UseVisualStyleBackColor = True
        '
        'txtBatchDescription
        '
        Me.txtBatchDescription.Location = New System.Drawing.Point(117, 12)
        Me.txtBatchDescription.Multiline = True
        Me.txtBatchDescription.Name = "txtBatchDescription"
        Me.txtBatchDescription.Size = New System.Drawing.Size(203, 61)
        Me.txtBatchDescription.TabIndex = 1
        Me.txtBatchDescription.Text = "New batch description"
        '
        'cboAddressTypeCodeID
        '
        Me.cboAddressTypeCodeID.FormattingEnabled = True
        Me.cboAddressTypeCodeID.Location = New System.Drawing.Point(108, 75)
        Me.cboAddressTypeCodeID.Name = "cboAddressTypeCodeID"
        Me.cboAddressTypeCodeID.Size = New System.Drawing.Size(203, 21)
        Me.cboAddressTypeCodeID.TabIndex = 2
        Me.cboAddressTypeCodeID.Tag = "ADDRESS_ADDRESSTYPECODEID"
        '
        'lblAddressType
        '
        Me.lblAddressType.AutoSize = True
        Me.lblAddressType.Location = New System.Drawing.Point(27, 78)
        Me.lblAddressType.Name = "lblAddressType"
        Me.lblAddressType.Size = New System.Drawing.Size(75, 13)
        Me.lblAddressType.TabIndex = 3
        Me.lblAddressType.Text = "Address Type:"
        '
        'lblCountry
        '
        Me.lblCountry.AutoSize = True
        Me.lblCountry.Location = New System.Drawing.Point(56, 105)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(46, 13)
        Me.lblCountry.TabIndex = 5
        Me.lblCountry.Text = "Country:"
        '
        'cboCountryID
        '
        Me.cboCountryID.FormattingEnabled = True
        Me.cboCountryID.Location = New System.Drawing.Point(108, 102)
        Me.cboCountryID.Name = "cboCountryID"
        Me.cboCountryID.Size = New System.Drawing.Size(203, 21)
        Me.cboCountryID.TabIndex = 4
        Me.cboCountryID.Tag = "ADDRESS_COUNTRYID"
        '
        'txtAddressBlock
        '
        Me.txtAddressBlock.Location = New System.Drawing.Point(108, 129)
        Me.txtAddressBlock.Multiline = True
        Me.txtAddressBlock.Name = "txtAddressBlock"
        Me.txtAddressBlock.Size = New System.Drawing.Size(203, 60)
        Me.txtAddressBlock.TabIndex = 6
        Me.txtAddressBlock.Tag = "ADDRESS_ADDRESSBLOCK"
        '
        'lblAddressBlock
        '
        Me.lblAddressBlock.AutoSize = True
        Me.lblAddressBlock.Location = New System.Drawing.Point(56, 129)
        Me.lblAddressBlock.Name = "lblAddressBlock"
        Me.lblAddressBlock.Size = New System.Drawing.Size(48, 13)
        Me.lblAddressBlock.TabIndex = 7
        Me.lblAddressBlock.Text = "Address:"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(108, 195)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(203, 20)
        Me.txtCity.TabIndex = 8
        Me.txtCity.Tag = "ADDRESS_CITY"
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Location = New System.Drawing.Point(75, 198)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(27, 13)
        Me.lblCity.TabIndex = 9
        Me.lblCity.Text = "City:"
        '
        'cboStateID
        '
        Me.cboStateID.FormattingEnabled = True
        Me.cboStateID.Location = New System.Drawing.Point(108, 219)
        Me.cboStateID.Name = "cboStateID"
        Me.cboStateID.Size = New System.Drawing.Size(203, 21)
        Me.cboStateID.TabIndex = 10
        Me.cboStateID.Tag = "ADDRESS_STATEID"
        '
        'lblStateID
        '
        Me.lblStateID.AutoSize = True
        Me.lblStateID.Location = New System.Drawing.Point(67, 222)
        Me.lblStateID.Name = "lblStateID"
        Me.lblStateID.Size = New System.Drawing.Size(35, 13)
        Me.lblStateID.TabIndex = 11
        Me.lblStateID.Text = "State:"
        '
        'lblPostCode
        '
        Me.lblPostCode.AutoSize = True
        Me.lblPostCode.Location = New System.Drawing.Point(43, 249)
        Me.lblPostCode.Name = "lblPostCode"
        Me.lblPostCode.Size = New System.Drawing.Size(59, 13)
        Me.lblPostCode.TabIndex = 13
        Me.lblPostCode.Text = "Post Code:"
        '
        'txtPostCode
        '
        Me.txtPostCode.Location = New System.Drawing.Point(108, 246)
        Me.txtPostCode.Name = "txtPostCode"
        Me.txtPostCode.Size = New System.Drawing.Size(126, 20)
        Me.txtPostCode.TabIndex = 12
        Me.txtPostCode.Tag = "ADDRESS_POSTCODE"
        '
        'cmdAddRowToBatch
        '
        Me.cmdAddRowToBatch.Enabled = False
        Me.cmdAddRowToBatch.Location = New System.Drawing.Point(322, 219)
        Me.cmdAddRowToBatch.Name = "cmdAddRowToBatch"
        Me.cmdAddRowToBatch.Size = New System.Drawing.Size(119, 48)
        Me.cmdAddRowToBatch.TabIndex = 14
        Me.cmdAddRowToBatch.Text = "Add Row To Batch"
        Me.cmdAddRowToBatch.UseVisualStyleBackColor = True
        '
        'cmdNewBatchRow
        '
        Me.cmdNewBatchRow.Enabled = False
        Me.cmdNewBatchRow.Location = New System.Drawing.Point(322, 19)
        Me.cmdNewBatchRow.Name = "cmdNewBatchRow"
        Me.cmdNewBatchRow.Size = New System.Drawing.Size(119, 24)
        Me.cmdNewBatchRow.TabIndex = 15
        Me.cmdNewBatchRow.Text = "New Batch Row"
        Me.cmdNewBatchRow.UseVisualStyleBackColor = True
        '
        'lblISOrganization
        '
        Me.lblISOrganization.AutoSize = True
        Me.lblISOrganization.Location = New System.Drawing.Point(14, 26)
        Me.lblISOrganization.Name = "lblISOrganization"
        Me.lblISOrganization.Size = New System.Drawing.Size(90, 13)
        Me.lblISOrganization.TabIndex = 16
        Me.lblISOrganization.Text = "Constituent Type:"
        '
        'cboConstituentType
        '
        Me.cboConstituentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConstituentType.FormattingEnabled = True
        Me.cboConstituentType.Items.AddRange(New Object() {"Individual", "Organization"})
        Me.cboConstituentType.Location = New System.Drawing.Point(108, 22)
        Me.cboConstituentType.Name = "cboConstituentType"
        Me.cboConstituentType.Size = New System.Drawing.Size(203, 21)
        Me.cboConstituentType.TabIndex = 17
        Me.cboConstituentType.Tag = "ISORGANIZATION"
        '
        'lblKeyName
        '
        Me.lblKeyName.AutoSize = True
        Me.lblKeyName.Location = New System.Drawing.Point(46, 52)
        Me.lblKeyName.Name = "lblKeyName"
        Me.lblKeyName.Size = New System.Drawing.Size(59, 13)
        Me.lblKeyName.TabIndex = 19
        Me.lblKeyName.Text = "Key Name:"
        '
        'txtKeyName
        '
        Me.txtKeyName.Location = New System.Drawing.Point(108, 49)
        Me.txtKeyName.Name = "txtKeyName"
        Me.txtKeyName.Size = New System.Drawing.Size(203, 20)
        Me.txtKeyName.TabIndex = 18
        Me.txtKeyName.Tag = "KEYNAME"
        '
        'cmdClearForm
        '
        Me.cmdClearForm.Location = New System.Drawing.Point(331, 377)
        Me.cmdClearForm.Name = "cmdClearForm"
        Me.cmdClearForm.Size = New System.Drawing.Size(119, 24)
        Me.cmdClearForm.TabIndex = 20
        Me.cmdClearForm.Text = "Clear Form"
        Me.cmdClearForm.UseVisualStyleBackColor = True
        '
        'lblBatchDescription
        '
        Me.lblBatchDescription.AutoSize = True
        Me.lblBatchDescription.Location = New System.Drawing.Point(17, 15)
        Me.lblBatchDescription.Name = "lblBatchDescription"
        Me.lblBatchDescription.Size = New System.Drawing.Size(94, 13)
        Me.lblBatchDescription.TabIndex = 21
        Me.lblBatchDescription.Text = "Batch Description:"
        '
        'grpAddress
        '
        Me.grpAddress.Controls.Add(Me.cmdNewBatchRow)
        Me.grpAddress.Controls.Add(Me.cboAddressTypeCodeID)
        Me.grpAddress.Controls.Add(Me.lblAddressType)
        Me.grpAddress.Controls.Add(Me.lblKeyName)
        Me.grpAddress.Controls.Add(Me.cboCountryID)
        Me.grpAddress.Controls.Add(Me.txtKeyName)
        Me.grpAddress.Controls.Add(Me.lblCountry)
        Me.grpAddress.Controls.Add(Me.cboConstituentType)
        Me.grpAddress.Controls.Add(Me.txtAddressBlock)
        Me.grpAddress.Controls.Add(Me.lblISOrganization)
        Me.grpAddress.Controls.Add(Me.lblAddressBlock)
        Me.grpAddress.Controls.Add(Me.txtCity)
        Me.grpAddress.Controls.Add(Me.cmdAddRowToBatch)
        Me.grpAddress.Controls.Add(Me.lblCity)
        Me.grpAddress.Controls.Add(Me.lblPostCode)
        Me.grpAddress.Controls.Add(Me.cboStateID)
        Me.grpAddress.Controls.Add(Me.txtPostCode)
        Me.grpAddress.Controls.Add(Me.lblStateID)
        Me.grpAddress.Enabled = False
        Me.grpAddress.Location = New System.Drawing.Point(9, 94)
        Me.grpAddress.Name = "grpAddress"
        Me.grpAddress.Size = New System.Drawing.Size(447, 277)
        Me.grpAddress.TabIndex = 22
        Me.grpAddress.TabStop = False
        Me.grpAddress.Text = "Enter New Constituent and Address Info"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 409)
        Me.Controls.Add(Me.grpAddress)
        Me.Controls.Add(Me.lblBatchDescription)
        Me.Controls.Add(Me.cmdClearForm)
        Me.Controls.Add(Me.txtBatchDescription)
        Me.Controls.Add(Me.cmdAddConstitBatch)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.grpAddress.ResumeLayout(False)
        Me.grpAddress.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAddConstitBatch As System.Windows.Forms.Button
    Friend WithEvents txtBatchDescription As System.Windows.Forms.TextBox
    Friend WithEvents cboAddressTypeCodeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAddressType As System.Windows.Forms.Label
    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents cboCountryID As System.Windows.Forms.ComboBox
    Friend WithEvents txtAddressBlock As System.Windows.Forms.TextBox
    Friend WithEvents lblAddressBlock As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents cboStateID As System.Windows.Forms.ComboBox
    Friend WithEvents lblStateID As System.Windows.Forms.Label
    Friend WithEvents lblPostCode As System.Windows.Forms.Label
    Friend WithEvents txtPostCode As System.Windows.Forms.TextBox
    Friend WithEvents cmdAddRowToBatch As System.Windows.Forms.Button
    Friend WithEvents cmdNewBatchRow As System.Windows.Forms.Button
    Friend WithEvents lblISOrganization As System.Windows.Forms.Label
    Friend WithEvents cboConstituentType As System.Windows.Forms.ComboBox
    Friend WithEvents lblKeyName As System.Windows.Forms.Label
    Friend WithEvents txtKeyName As System.Windows.Forms.TextBox
    Friend WithEvents cmdClearForm As System.Windows.Forms.Button
    Friend WithEvents lblBatchDescription As System.Windows.Forms.Label
    Friend WithEvents grpAddress As System.Windows.Forms.GroupBox
End Class
