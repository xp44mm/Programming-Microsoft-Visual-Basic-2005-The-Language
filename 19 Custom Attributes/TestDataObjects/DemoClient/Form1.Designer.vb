<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.btnFill = New System.Windows.Forms.Button
      Me.dgvCustomers = New System.Windows.Forms.DataGridView
      Me.CustomerIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.CompanyNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ContactNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ContactTitleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.AddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.CityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.RegionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.PostalCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.CountryDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.PhoneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.FaxDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.bsCustomers = New System.Windows.Forms.BindingSource(Me.components)
      Me.NwindDataSet1 = New DataSets.NWINDDataSet
      Me.dvgOrders = New System.Windows.Forms.DataGridView
      Me.OrderIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.CustomerIDDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.EmployeeIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.OrderDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.RequiredDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ShippedDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ShipViaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.FreightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ShipNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ShipAddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ShipCityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ShipRegionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ShipPostalCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ShipCountryDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.bsCustomersOrders = New System.Windows.Forms.BindingSource(Me.components)
      Me.btnUpdate = New System.Windows.Forms.Button
      CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bsCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.NwindDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dvgOrders, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bsCustomersOrders, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnFill
      '
      Me.btnFill.Location = New System.Drawing.Point(22, 21)
      Me.btnFill.Name = "btnFill"
      Me.btnFill.Size = New System.Drawing.Size(75, 23)
      Me.btnFill.TabIndex = 0
      Me.btnFill.Text = "Fill"
      Me.btnFill.UseVisualStyleBackColor = True
      '
      'dgvCustomers
      '
      Me.dgvCustomers.AutoGenerateColumns = False
      Me.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvCustomers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustomerIDDataGridViewTextBoxColumn, Me.CompanyNameDataGridViewTextBoxColumn, Me.ContactNameDataGridViewTextBoxColumn, Me.ContactTitleDataGridViewTextBoxColumn, Me.AddressDataGridViewTextBoxColumn, Me.CityDataGridViewTextBoxColumn, Me.RegionDataGridViewTextBoxColumn, Me.PostalCodeDataGridViewTextBoxColumn, Me.CountryDataGridViewTextBoxColumn, Me.PhoneDataGridViewTextBoxColumn, Me.FaxDataGridViewTextBoxColumn})
      Me.dgvCustomers.DataSource = Me.bsCustomers
      Me.dgvCustomers.Location = New System.Drawing.Point(22, 60)
      Me.dgvCustomers.Name = "dgvCustomers"
      Me.dgvCustomers.Size = New System.Drawing.Size(800, 203)
      Me.dgvCustomers.TabIndex = 1
      '
      'CustomerIDDataGridViewTextBoxColumn
      '
      Me.CustomerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID"
      Me.CustomerIDDataGridViewTextBoxColumn.HeaderText = "CustomerID"
      Me.CustomerIDDataGridViewTextBoxColumn.Name = "CustomerIDDataGridViewTextBoxColumn"
      '
      'CompanyNameDataGridViewTextBoxColumn
      '
      Me.CompanyNameDataGridViewTextBoxColumn.DataPropertyName = "CompanyName"
      Me.CompanyNameDataGridViewTextBoxColumn.HeaderText = "CompanyName"
      Me.CompanyNameDataGridViewTextBoxColumn.Name = "CompanyNameDataGridViewTextBoxColumn"
      '
      'ContactNameDataGridViewTextBoxColumn
      '
      Me.ContactNameDataGridViewTextBoxColumn.DataPropertyName = "ContactName"
      Me.ContactNameDataGridViewTextBoxColumn.HeaderText = "ContactName"
      Me.ContactNameDataGridViewTextBoxColumn.Name = "ContactNameDataGridViewTextBoxColumn"
      '
      'ContactTitleDataGridViewTextBoxColumn
      '
      Me.ContactTitleDataGridViewTextBoxColumn.DataPropertyName = "ContactTitle"
      Me.ContactTitleDataGridViewTextBoxColumn.HeaderText = "ContactTitle"
      Me.ContactTitleDataGridViewTextBoxColumn.Name = "ContactTitleDataGridViewTextBoxColumn"
      '
      'AddressDataGridViewTextBoxColumn
      '
      Me.AddressDataGridViewTextBoxColumn.DataPropertyName = "Address"
      Me.AddressDataGridViewTextBoxColumn.HeaderText = "Address"
      Me.AddressDataGridViewTextBoxColumn.Name = "AddressDataGridViewTextBoxColumn"
      '
      'CityDataGridViewTextBoxColumn
      '
      Me.CityDataGridViewTextBoxColumn.DataPropertyName = "City"
      Me.CityDataGridViewTextBoxColumn.HeaderText = "City"
      Me.CityDataGridViewTextBoxColumn.Name = "CityDataGridViewTextBoxColumn"
      '
      'RegionDataGridViewTextBoxColumn
      '
      Me.RegionDataGridViewTextBoxColumn.DataPropertyName = "Region"
      Me.RegionDataGridViewTextBoxColumn.HeaderText = "Region"
      Me.RegionDataGridViewTextBoxColumn.Name = "RegionDataGridViewTextBoxColumn"
      '
      'PostalCodeDataGridViewTextBoxColumn
      '
      Me.PostalCodeDataGridViewTextBoxColumn.DataPropertyName = "PostalCode"
      Me.PostalCodeDataGridViewTextBoxColumn.HeaderText = "PostalCode"
      Me.PostalCodeDataGridViewTextBoxColumn.Name = "PostalCodeDataGridViewTextBoxColumn"
      '
      'CountryDataGridViewTextBoxColumn
      '
      Me.CountryDataGridViewTextBoxColumn.DataPropertyName = "Country"
      Me.CountryDataGridViewTextBoxColumn.HeaderText = "Country"
      Me.CountryDataGridViewTextBoxColumn.Name = "CountryDataGridViewTextBoxColumn"
      '
      'PhoneDataGridViewTextBoxColumn
      '
      Me.PhoneDataGridViewTextBoxColumn.DataPropertyName = "Phone"
      Me.PhoneDataGridViewTextBoxColumn.HeaderText = "Phone"
      Me.PhoneDataGridViewTextBoxColumn.Name = "PhoneDataGridViewTextBoxColumn"
      '
      'FaxDataGridViewTextBoxColumn
      '
      Me.FaxDataGridViewTextBoxColumn.DataPropertyName = "Fax"
      Me.FaxDataGridViewTextBoxColumn.HeaderText = "Fax"
      Me.FaxDataGridViewTextBoxColumn.Name = "FaxDataGridViewTextBoxColumn"
      '
      'bsCustomers
      '
      Me.bsCustomers.DataMember = "Customers"
      Me.bsCustomers.DataSource = Me.NwindDataSet1
      '
      'NwindDataSet1
      '
      Me.NwindDataSet1.DataSetName = "NWINDDataSet"
      Me.NwindDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'dvgOrders
      '
      Me.dvgOrders.AutoGenerateColumns = False
      Me.dvgOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dvgOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderIDDataGridViewTextBoxColumn, Me.CustomerIDDataGridViewTextBoxColumn1, Me.EmployeeIDDataGridViewTextBoxColumn, Me.OrderDateDataGridViewTextBoxColumn, Me.RequiredDateDataGridViewTextBoxColumn, Me.ShippedDateDataGridViewTextBoxColumn, Me.ShipViaDataGridViewTextBoxColumn, Me.FreightDataGridViewTextBoxColumn, Me.ShipNameDataGridViewTextBoxColumn, Me.ShipAddressDataGridViewTextBoxColumn, Me.ShipCityDataGridViewTextBoxColumn, Me.ShipRegionDataGridViewTextBoxColumn, Me.ShipPostalCodeDataGridViewTextBoxColumn, Me.ShipCountryDataGridViewTextBoxColumn})
      Me.dvgOrders.DataSource = Me.bsCustomersOrders
      Me.dvgOrders.Location = New System.Drawing.Point(22, 279)
      Me.dvgOrders.Name = "dvgOrders"
      Me.dvgOrders.Size = New System.Drawing.Size(800, 146)
      Me.dvgOrders.TabIndex = 2
      '
      'OrderIDDataGridViewTextBoxColumn
      '
      Me.OrderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID"
      Me.OrderIDDataGridViewTextBoxColumn.HeaderText = "OrderID"
      Me.OrderIDDataGridViewTextBoxColumn.Name = "OrderIDDataGridViewTextBoxColumn"
      '
      'CustomerIDDataGridViewTextBoxColumn1
      '
      Me.CustomerIDDataGridViewTextBoxColumn1.DataPropertyName = "CustomerID"
      Me.CustomerIDDataGridViewTextBoxColumn1.HeaderText = "CustomerID"
      Me.CustomerIDDataGridViewTextBoxColumn1.Name = "CustomerIDDataGridViewTextBoxColumn1"
      '
      'EmployeeIDDataGridViewTextBoxColumn
      '
      Me.EmployeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID"
      Me.EmployeeIDDataGridViewTextBoxColumn.HeaderText = "EmployeeID"
      Me.EmployeeIDDataGridViewTextBoxColumn.Name = "EmployeeIDDataGridViewTextBoxColumn"
      '
      'OrderDateDataGridViewTextBoxColumn
      '
      Me.OrderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate"
      Me.OrderDateDataGridViewTextBoxColumn.HeaderText = "OrderDate"
      Me.OrderDateDataGridViewTextBoxColumn.Name = "OrderDateDataGridViewTextBoxColumn"
      '
      'RequiredDateDataGridViewTextBoxColumn
      '
      Me.RequiredDateDataGridViewTextBoxColumn.DataPropertyName = "RequiredDate"
      Me.RequiredDateDataGridViewTextBoxColumn.HeaderText = "RequiredDate"
      Me.RequiredDateDataGridViewTextBoxColumn.Name = "RequiredDateDataGridViewTextBoxColumn"
      '
      'ShippedDateDataGridViewTextBoxColumn
      '
      Me.ShippedDateDataGridViewTextBoxColumn.DataPropertyName = "ShippedDate"
      Me.ShippedDateDataGridViewTextBoxColumn.HeaderText = "ShippedDate"
      Me.ShippedDateDataGridViewTextBoxColumn.Name = "ShippedDateDataGridViewTextBoxColumn"
      '
      'ShipViaDataGridViewTextBoxColumn
      '
      Me.ShipViaDataGridViewTextBoxColumn.DataPropertyName = "ShipVia"
      Me.ShipViaDataGridViewTextBoxColumn.HeaderText = "ShipVia"
      Me.ShipViaDataGridViewTextBoxColumn.Name = "ShipViaDataGridViewTextBoxColumn"
      '
      'FreightDataGridViewTextBoxColumn
      '
      Me.FreightDataGridViewTextBoxColumn.DataPropertyName = "Freight"
      Me.FreightDataGridViewTextBoxColumn.HeaderText = "Freight"
      Me.FreightDataGridViewTextBoxColumn.Name = "FreightDataGridViewTextBoxColumn"
      '
      'ShipNameDataGridViewTextBoxColumn
      '
      Me.ShipNameDataGridViewTextBoxColumn.DataPropertyName = "ShipName"
      Me.ShipNameDataGridViewTextBoxColumn.HeaderText = "ShipName"
      Me.ShipNameDataGridViewTextBoxColumn.Name = "ShipNameDataGridViewTextBoxColumn"
      '
      'ShipAddressDataGridViewTextBoxColumn
      '
      Me.ShipAddressDataGridViewTextBoxColumn.DataPropertyName = "ShipAddress"
      Me.ShipAddressDataGridViewTextBoxColumn.HeaderText = "ShipAddress"
      Me.ShipAddressDataGridViewTextBoxColumn.Name = "ShipAddressDataGridViewTextBoxColumn"
      '
      'ShipCityDataGridViewTextBoxColumn
      '
      Me.ShipCityDataGridViewTextBoxColumn.DataPropertyName = "ShipCity"
      Me.ShipCityDataGridViewTextBoxColumn.HeaderText = "ShipCity"
      Me.ShipCityDataGridViewTextBoxColumn.Name = "ShipCityDataGridViewTextBoxColumn"
      '
      'ShipRegionDataGridViewTextBoxColumn
      '
      Me.ShipRegionDataGridViewTextBoxColumn.DataPropertyName = "ShipRegion"
      Me.ShipRegionDataGridViewTextBoxColumn.HeaderText = "ShipRegion"
      Me.ShipRegionDataGridViewTextBoxColumn.Name = "ShipRegionDataGridViewTextBoxColumn"
      '
      'ShipPostalCodeDataGridViewTextBoxColumn
      '
      Me.ShipPostalCodeDataGridViewTextBoxColumn.DataPropertyName = "ShipPostalCode"
      Me.ShipPostalCodeDataGridViewTextBoxColumn.HeaderText = "ShipPostalCode"
      Me.ShipPostalCodeDataGridViewTextBoxColumn.Name = "ShipPostalCodeDataGridViewTextBoxColumn"
      '
      'ShipCountryDataGridViewTextBoxColumn
      '
      Me.ShipCountryDataGridViewTextBoxColumn.DataPropertyName = "ShipCountry"
      Me.ShipCountryDataGridViewTextBoxColumn.HeaderText = "ShipCountry"
      Me.ShipCountryDataGridViewTextBoxColumn.Name = "ShipCountryDataGridViewTextBoxColumn"
      '
      'bsCustomersOrders
      '
      Me.bsCustomersOrders.DataMember = "CustomersOrders"
      Me.bsCustomersOrders.DataSource = Me.bsCustomers
      '
      'btnUpdate
      '
      Me.btnUpdate.Location = New System.Drawing.Point(112, 21)
      Me.btnUpdate.Name = "btnUpdate"
      Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
      Me.btnUpdate.TabIndex = 3
      Me.btnUpdate.Text = "Update"
      Me.btnUpdate.UseVisualStyleBackColor = True
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(840, 434)
      Me.Controls.Add(Me.btnUpdate)
      Me.Controls.Add(Me.dvgOrders)
      Me.Controls.Add(Me.dgvCustomers)
      Me.Controls.Add(Me.btnFill)
      Me.Name = "Form1"
      Me.Text = "Form1"
      CType(Me.dgvCustomers, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bsCustomers, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.NwindDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dvgOrders, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bsCustomersOrders, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents NwindDataSet1 As DataSets.NWINDDataSet
   Friend WithEvents btnFill As System.Windows.Forms.Button
   Friend WithEvents bsCustomers As System.Windows.Forms.BindingSource
   Friend WithEvents dgvCustomers As System.Windows.Forms.DataGridView
   Friend WithEvents CustomerIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CompanyNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ContactNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ContactTitleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents AddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents RegionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PostalCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CountryDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PhoneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FaxDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents dvgOrders As System.Windows.Forms.DataGridView
   Friend WithEvents OrderIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CustomerIDDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents EmployeeIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents OrderDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents RequiredDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ShippedDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ShipViaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FreightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ShipNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ShipAddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ShipCityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ShipRegionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ShipPostalCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ShipCountryDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents bsCustomersOrders As System.Windows.Forms.BindingSource
   Friend WithEvents btnUpdate As System.Windows.Forms.Button

End Class
