

Public Class Form1
    'update the values for your system settings
    Const serviceUrlBasePath As String = "http://localhost/bbappfx/"
    Const databaseName As String = "BBInfinity"
    Const applicationTitle As String = "BatchWebAPISample"

    Private _helper As BatchHelper
    Private _currentBatchID As System.Guid
    Private _batchRowSequence As Integer = 0

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Initialize()
    End Sub

    Private Sub cmdAddConstitBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddConstitBatch.Click
        'Pass the identifier for the appropriate batch template.
        'Note:  this code assumes the batch template has already been created.
        'The batch template is based upon the constituent batch type.
        'Create your own batch template from the constituent batch type and lookup
        'the batch template id within the BATCHTEMPLATE table.  Or you can use WSREQUESTLOG
        'to sniff out the batch template id by logging the call to the BatchSaveRequest from the
        'AppFxWebService.  

        '00a0e05b-2c04-4c33-be23-1e79bb21d789
        _currentBatchID = _helper.CreateBatchFromTemplate(New System.Guid("D7C8F295-28D1-4228-9088-7927D3CBAAC2"), _
                                                        Me.txtBatchDescription.Text)
        Me.grpAddress.Enabled = True
        Me.cmdNewBatchRow.Enabled = True
    End Sub
    Private Sub Initialize()
        _helper = New BatchHelper(serviceUrlBasePath, databaseName, applicationTitle)

        Me.cboStateID.Items.AddRange(_helper.GetStates.ToArray)
        Me.cboCountryID.Items.AddRange(_helper.GetCountries.ToArray)
        Me.cboAddressTypeCodeID.Items.AddRange(_helper.GetAddressTypes.ToArray)
    End Sub

    Private Sub EvaluateAddBatchButton()
        If Me.txtBatchDescription.Text.Length > 0 Then
            Me.cmdAddConstitBatch.Enabled = True
        Else
            Me.cmdAddConstitBatch.Enabled = False
        End If
    End Sub

    Private Sub txtBatchDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBatchDescription.TextChanged
        EvaluateAddBatchButton()
    End Sub

 


   

    Private Sub cmdClearForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearForm.Click
        Me.txtBatchDescription.Text = ""

        ClearBatchRow()

        Me.grpAddress.Enabled = False
        Me.cmdNewBatchRow.Enabled = False

        cmdAddRowToBatch.Enabled = CheckEnableAddRowToBatchButton()
    End Sub

    Private Sub cmdAddRowToBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddRowToBatch.Click
        Dim SaveRequestGUID As System.Guid
        Dim BatchRowValues As New Generic.Dictionary(Of String, String)
        Dim ISORGANIZATION As System.Int16

        Try
            If Me.cboConstituentType.Text = "Individual" Then
                ISORGANIZATION = 0
            Else
                ISORGANIZATION = 1
            End If

            BatchRowValues.Add(Me.cboConstituentType.Tag.ToString, ISORGANIZATION.ToString)
            BatchRowValues.Add(Me.txtKeyName.Tag.ToString, Me.txtKeyName.Text.ToString)
            BatchRowValues.Add(Me.cboAddressTypeCodeID.Tag.ToString, CType(Me.cboAddressTypeCodeID.SelectedItem, SimpleAddressType).AddressType.ToString)
            BatchRowValues.Add(Me.txtAddressBlock.Tag.ToString, Me.txtAddressBlock.Text.ToString)
            BatchRowValues.Add(Me.txtCity.Tag.ToString, Me.txtCity.Text.ToString)

            BatchRowValues.Add(Me.cboStateID.Tag.ToString, CType(Me.cboStateID.SelectedItem, SimpleState).StateID.ToString)
            BatchRowValues.Add(Me.cboCountryID.Tag.ToString, CType(Me.cboCountryID.SelectedItem, SimpleCountry).CountryID.ToString)
            BatchRowValues.Add(Me.txtPostCode.Tag.ToString, Me.txtPostCode.Text.ToString)

            _batchRowSequence += 1
            SaveRequestGUID = _helper.BatchSaveRequest(_currentBatchID, BatchRowValues, _batchRowSequence)

            ClearBatchRow()
            cmdAddRowToBatch.Enabled = CheckEnableAddRowToBatchButton()

        Catch ex As BatchException
            MsgBox(ex.BatchErrorMessage, MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearBatchRow()

        Me.cboConstituentType.SelectedIndex = -1
        Me.txtKeyName.Text = ""
        Me.cboAddressTypeCodeID.SelectedIndex = -1
        Me.txtAddressBlock.Text = ""
        Me.txtCity.Text = ""
        Me.cboStateID.SelectedIndex = -1
        Me.cboCountryID.SelectedIndex = -1
        Me.txtPostCode.Text = ""

    End Sub


    Private Function CheckEnableAddRowToBatchButton() As Boolean

        If Me.cboConstituentType.SelectedIndex = -1 Then
            Return False
        End If

        If Me.txtKeyName.Text.Length = 0 Then
            Return False
        End If

        If Me.cboAddressTypeCodeID.SelectedIndex = -1 Then
            Return False
        End If

        If Me.txtAddressBlock.Text.Length = 0 Then
            Return False
        End If

        If Me.txtCity.Text.Length = 0 Then
            Return False
        End If

        If Me.cboStateID.SelectedIndex = -1 Then
            Return False
        End If

        If Me.cboCountryID.SelectedIndex = -1 Then
            Return False
        End If

        If Me.txtPostCode.Text.Length = 0 Then
            Return False
        End If

        Return True

    End Function

    Private Sub cboConstituentType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboConstituentType.SelectedIndexChanged
        cmdAddRowToBatch.Enabled = CheckEnableAddRowToBatchButton()
    End Sub

    Private Sub txtKeyName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKeyName.TextChanged
        cmdAddRowToBatch.Enabled = CheckEnableAddRowToBatchButton()
    End Sub

    Private Sub cboAddressTypeCodeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddressTypeCodeID.SelectedIndexChanged
        cmdAddRowToBatch.Enabled = CheckEnableAddRowToBatchButton()
    End Sub

    Private Sub cboCountryID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCountryID.SelectedIndexChanged
        cmdAddRowToBatch.Enabled = CheckEnableAddRowToBatchButton()
    End Sub

    Private Sub txtAddressBlock_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddressBlock.TextChanged
        cmdAddRowToBatch.Enabled = CheckEnableAddRowToBatchButton()
    End Sub

    Private Sub txtCity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCity.TextChanged
        cmdAddRowToBatch.Enabled = CheckEnableAddRowToBatchButton()
    End Sub

    Private Sub cboStateID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStateID.SelectedIndexChanged
        cmdAddRowToBatch.Enabled = CheckEnableAddRowToBatchButton()
    End Sub

    Private Sub txtPostCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPostCode.TextChanged
        cmdAddRowToBatch.Enabled = CheckEnableAddRowToBatchButton()
    End Sub

    Private Sub cmdNewBatchRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewBatchRow.Click
        ClearBatchRow()
        cmdAddRowToBatch.Enabled = CheckEnableAddRowToBatchButton()
    End Sub
End Class