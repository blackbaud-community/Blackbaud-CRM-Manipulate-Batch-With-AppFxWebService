

Public Class BatchHelper

    Dim _serviceUrlBasePath As String
    Dim _databaseName As String
    Dim _provider As Blackbaud.AppFx.WebAPI.AppFxWebServiceProvider
    Dim _applicationTitle As String = "BatchWebAPISample"
    Dim _service As New Blackbaud.AppFx.WebAPI.ServiceProxy.AppFxWebService

    Public Sub New(ByVal ServiceUrlBasePath As String, ByVal DatabaseName As String, ByVal _applicationTitle As String)
        _serviceUrlBasePath = ServiceUrlBasePath
        _databaseName = DatabaseName

        'The provider is used whenever we talk to the infinity web server (AppFxWebService)
        'via the Blackbaud.AppFx.WebAPI.dll.  The provider points us to the correct url of the web service
        ' and the correct database
        _provider = New Blackbaud.AppFx.WebAPI.AppFxWebServiceProvider
        _provider.Url = String.Concat(_serviceUrlBasePath, "appfxwebservice.asmx")
        _provider.Database = _databaseName

        'supply credentials to authenticate
        'When creating your connection to the Infinity web service 
        'you can use any set of windows credentials you would like. 
        'By doing so the security applied to that login is applied to this connection. 
        'This is the same security model as that applied by the Blackbaud smart client.
        _provider.Credentials = System.Net.CredentialCache.DefaultCredentials

        _service.Url = String.Concat(_serviceUrlBasePath, "appfxwebservice.asmx")
        _service.Credentials = System.Net.CredentialCache.DefaultCredentials

    End Sub

    Public Function CreateBatchFromTemplate(ByVal BatchTemplateID As System.Guid, ByVal BatchDescription As String) As System.Guid

        Dim DataFormValues As New Generic.Dictionary(Of String, String)

        'add the batch template id and description into the values in the generic.dictionary for the payload
        DataFormValues.Add("BATCHTEMPLATEID", BatchTemplateID.ToString)
        DataFormValues.Add("DESCRIPTION", BatchDescription)

        'The first parameter passed to DataFormSave is the data form instance Id of 
        'the data form that creates a new batch from a specified batch template.  
        'The second parameter is a generic.dictionary of form field values used as the payload
        'included in the payload is the batch template id.
        Return DataFormSave(New System.Guid("0197ed14-16bc-419b-8ba3-b81beb64b8f2"), DataFormValues)

    End Function

    Public Function BatchSaveRequest(ByVal BatchID As System.Guid, _
                                     ByVal BatchRowValues As Generic.Dictionary(Of String, String), _
                                     ByVal BatchRowSequence As Integer) As System.Guid

        Dim req As New Blackbaud.AppFx.WebAPI.ServiceProxy.BatchSaveRequest

        Dim reply As New Blackbaud.AppFx.WebAPI.ServiceProxy.BatchSaveReply

        req.ClientAppInfo = GetRequestHeader()
        req.BatchID = BatchID

        Dim BatchDataRow As New Blackbaud.AppFx.WebAPI.ServiceProxy.BatchDataRow
        Dim BatchDataRows(0) As Blackbaud.AppFx.WebAPI.ServiceProxy.BatchDataRow
        BatchDataRow.ID = System.Guid.NewGuid.ToString
        BatchDataRow.AddRow = True

        'We will convert the generic.dictionary of form field values into a 
        'generic.list of DataFormFieldValues which is used within AddRange a few lines of code below.
        Dim DataFormItem As New Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem
        Dim DataFormFieldValueList As New Generic.List(Of Blackbaud.AppFx.XmlTypes.DataForms.DataFormFieldValue)
        For Each DataFormValueKey In BatchRowValues.Keys
            DataFormFieldValueList.Add(New Blackbaud.AppFx.XmlTypes.DataForms.DataFormFieldValue(DataFormValueKey, BatchRowValues(DataFormValueKey)))
        Next
        DataFormFieldValueList.Add(New Blackbaud.AppFx.XmlTypes.DataForms.DataFormFieldValue("SEQUENCE", BatchRowSequence))
        'AddRange accepts an IList of dataformfieldvalues.  This will provide the 
        'DataFormSaveRequest with its payload of form field values to save.  
        DataFormItem.Values.AddRange(DataFormFieldValueList)

        BatchDataRow.DataFormItem = DataFormItem
        BatchDataRow.ExceptionMessageTypeCode = Blackbaud.AppFx.WebAPI.ServiceProxy.BatchMessageType.GeneralError
        BatchDataRow.ClearUserMessage = False
        BatchDataRow.ClearSystemMessage = False
        BatchDataRow.IgnoreDuplicate = False

        BatchDataRows(0) = BatchDataRow
        req.Rows = BatchDataRows

        reply = _service.BatchSave(req)

        If Not reply.Exceptions Is Nothing Then
            If reply.Exceptions.Count > 0 Then
                Dim ex As New BatchException("Batch Save Error")
                ex.BatchSaveReply = reply
                Throw ex
                Exit Function
            End If
        End If



    End Function

    Public Function DataFormSave(ByVal FormID As System.Guid, ByVal DataFormValues As Generic.Dictionary(Of String, String)) As System.Guid

        'This function accepts the data form instance id of a data form and 
        'a dictionary of form field keys and values.

        'The DataFormItem is the payload that is sent as part of the DataFormSaveRequest
        'We will place a list of data form field values within this object.
        Dim DataFormItem As New Blackbaud.AppFx.XmlTypes.DataForms.DataFormItem

        'We will convert the generic.dictionary of form field values into a 
        'generic.list of DataFormFieldValues which is used within AddRange a few lines of code below.
        Dim DataFormFieldValueList As New Generic.List(Of Blackbaud.AppFx.XmlTypes.DataForms.DataFormFieldValue)
        For Each DataFormValueKey In DataFormValues.Keys
            DataFormFieldValueList.Add(New Blackbaud.AppFx.XmlTypes.DataForms.DataFormFieldValue(DataFormValueKey, DataFormValues(DataFormValueKey)))
        Next

        'AddRange accepts an IList of dataformfieldvalues.  This will provide the 
        'DataFormSaveRequest with its payload of form field values to save.  
        DataFormItem.Values.AddRange(DataFormFieldValueList)

        'Get a new save request and provide the request with the payload (DataFormItem)
        Dim req As Blackbaud.AppFx.WebAPI.ServiceProxy.DataFormSaveRequest = Blackbaud.AppFx.WebAPI.DataFormServices.CreateDataFormSaveRequest(_provider, FormID)
        req.DataFormItem = DataFormItem

        'save the data (data form save request) and catch the new batch id that is created as part of the 
        'save into BatchID.  Check out the Batch table within the database.  If all goes well then at this
        'point we have created a new batch from a batch template.  
        Dim BatchID As String
        BatchID = Blackbaud.AppFx.WebAPI.DataFormServices.SaveData(_provider, req)

        'Return the batch id from the function.  
        'Our code can use the batch id later when it comes time to add data to the new batch.
        Return New System.Guid(BatchID)

    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Initialize States
    'Using the GUID that identifies the State Abbreviation List (Simple Data List_
    'Retrieve a listing of states and return a generic list of type SimpleState
    'this will be used within the user interface to populate the combo box with a key, value pair.
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function GetStates() As Generic.List(Of SimpleState)
        Dim States() As Blackbaud.AppFx.WebAPI.SimpleDataListsData
        States = Blackbaud.AppFx.WebAPI.SimpleDataLists.LoadSimpleDataList(_provider, New System.Guid("7fa91401-596c-4f7c-936d-6e41683121d7"))

        Dim SimpleStates As New Generic.List(Of SimpleState)
        For Each State As Blackbaud.AppFx.WebAPI.SimpleDataListsData In States
            SimpleStates.Add(New SimpleState(State.Value, State.Label))
        Next

        Return SimpleStates
    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Initialize Address Types
    'Grab a list of address types from the AddressType code table
    'Populate the address types combo box with a key, value pair
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function GetAddressTypes() As Generic.List(Of SimpleAddressType)
        Dim AddressTypes() As Blackbaud.AppFx.WebAPI.CodeTableEntryItem
        AddressTypes = Blackbaud.AppFx.WebAPI.CodeTableServices.GetList(_provider, "AddressTypeCode", Blackbaud.AppFx.WebAPI.CodeTableEntryIncludeOption.IncludeActiveOnly)

        Dim AddressTypeCodeTable As New Generic.List(Of SimpleAddressType)
        For Each AddressType As Blackbaud.AppFx.WebAPI.CodeTableEntryItem In AddressTypes
            AddressTypeCodeTable.Add(New SimpleAddressType(AddressType.EntryID, AddressType.Description))
        Next

        Return AddressTypeCodeTable
    End Function


    Public Function GetCountries() As Generic.List(Of SimpleCountry)
        Dim Countries() As Blackbaud.AppFx.WebAPI.SimpleDataListsData
        Countries = Blackbaud.AppFx.WebAPI.SimpleDataLists.LoadSimpleDataList(_provider, New System.Guid("c9649672-353d-42e8-8c25-4d34bbabfbba"))

        Dim SimpleCountries As New Generic.List(Of SimpleCountry)
        For Each Country As Blackbaud.AppFx.WebAPI.SimpleDataListsData In Countries
            SimpleCountries.Add(New SimpleCountry(Country.Value, Country.Label))
        Next

        Return SimpleCountries
    End Function

    Private Function GetRequestHeader() As Blackbaud.AppFx.WebAPI.ServiceProxy.ClientAppInfoHeader

        'Create the client app header (all requests require this)
        Dim header As New Blackbaud.AppFx.WebAPI.ServiceProxy.ClientAppInfoHeader

        'Provide some name to distinguish this application using the service.  This name will ultimately be passed to the 
        'database, so don't make this random or per user or you won't benefit from connection pooling.
        header.ClientAppName = _applicationTitle

        'A single webservice instance can serve multiple databases.
        'You must specify the database for every request.  The list of available databases is what you see in the login form.
        header.REDatabaseToUse = _databaseName

        Return header

    End Function

End Class





#Region "Helper Classes"

Public Class SimpleState
    Private _key As Object ' Guid for the state
    Private _value As String ' State Abbrev
    Public Sub New(ByVal StateGUID As Object, ByVal StateAbbrev As String)
        _key = StateGUID
        _value = StateAbbrev
    End Sub

    Public ReadOnly Property StateID() As String
        Get
            Return _key.ToString
        End Get
    End Property

    Public ReadOnly Property StateAbbrev() As String
        Get
            Return _value
        End Get
    End Property


    Public Overrides Function ToString() As String
        Return _value
    End Function

End Class

Public Class SimpleAddressType
    Private _key As Object ' Guid for the address type
    Private _value As String ' address type description
    Public Sub New(ByVal Key As Object, ByVal Value As String)
        _key = Key
        _value = Value
    End Sub

    Public ReadOnly Property AddressType() As System.Guid
        Get
            Return New System.Guid(_key.ToString)
        End Get
    End Property

    Public ReadOnly Property AddressTypeDesc() As String
        Get
            Return _value
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return _value
    End Function

End Class

Public Class SimpleCountry
    Private _key As Object ' Guid for the state
    Private _value As String ' State Abbrev
    Public Sub New(ByVal CountryID As Object, ByVal Country As String)
        _key = CountryID
        _value = Country
    End Sub

    Public ReadOnly Property CountryID() As String
        Get
            Return _key.ToString
        End Get
    End Property

    Public ReadOnly Property Country() As String
        Get
            Return _value
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return _value
    End Function
End Class


Public Class BatchException
    Inherits Exception
    Implements System.Runtime.Serialization.ISerializable
    'Private _batchrowexceptions() As Blackbaud.AppFx.WebAPI.ServiceProxy.BatchRowException
    Private _batchSaveReply As Blackbaud.AppFx.WebAPI.ServiceProxy.BatchSaveReply
    Private _batchErrorMessage As String


    Public Sub New()
        MyBase.New()
        ' Add implementation.
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
        ' Add implementation.
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As Exception)
        MyBase.New(message, inner)
        ' Add implementation.
    End Sub

    ' This constructor is needed for serialization.
    Protected Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
        MyBase.New(info, context)
        ' Add implementation.
    End Sub

    'Public Property BatchRowExceptions() As Blackbaud.AppFx.WebAPI.ServiceProxy.BatchRowException()
    '    Set(ByVal value As Blackbaud.AppFx.WebAPI.ServiceProxy.BatchRowException())
    '        _batchrowexceptions = value
    '    End Set
    '    Get
    '        Return _batchrowexceptions
    '    End Get
    'End Property

    Public Property BatchSaveReply() As Blackbaud.AppFx.WebAPI.ServiceProxy.BatchSaveReply
        Set(ByVal value As Blackbaud.AppFx.WebAPI.ServiceProxy.BatchSaveReply)
            _batchSaveReply = value

            Dim message As String = ""
            For Each batchrowexception As Blackbaud.AppFx.WebAPI.ServiceProxy.BatchRowException In _batchSaveReply.Exceptions
                message &= "Batch Error Type:  " & batchrowexception.ErrorMessageTypeCode.ToString & vbCrLf & _
                "Invalid Field ID: " & batchrowexception.InvalidFieldID.ToString & vbCrLf & _
                " - " & batchrowexception.ErrorMessage.ToString & vbCrLf & vbCrLf
                'message &= batchrowexception.ToString & vbCrLf
            Next

            _batchErrorMessage = message
        End Set
        Get
            Return _batchSaveReply
        End Get
    End Property

    Public ReadOnly Property BatchErrorMessage() As String
        Get
            Return _batchErrorMessage
        End Get
    End Property

End Class



'''' <summary>
'''' This class contains two properties.
'''' </summary>
'Public Class Address
'    Dim _StreetAddress As String
'    Dim _AddressTypeDesc As String
'    Dim _AddressID As String

'    Public Sub New(ByVal AddressID As String, ByVal StreetAddress As String, ByVal AddressTypeDesc As String)
'        _AddressID = AddressID
'        _StreetAddress = StreetAddress
'        _AddressTypeDesc = AddressTypeDesc
'    End Sub

'    Public ReadOnly Property AddressID() As String
'        Get
'            Return _AddressID
'        End Get
'    End Property

'    Public ReadOnly Property StreetAddress() As String
'        Get
'            Return _StreetAddress
'        End Get
'    End Property

'    Public ReadOnly Property AddressTypeDesc() As String
'        Get
'            Return _AddressTypeDesc
'        End Get
'    End Property
'End Class

#End Region
