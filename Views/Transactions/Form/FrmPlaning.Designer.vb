﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlaning
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtPONo = New System.Windows.Forms.TextBox()
        Me.btnView = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPINo = New System.Windows.Forms.TextBox()
        Me.dtERD = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtSD = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtPODate = New System.Windows.Forms.DateTimePicker()
        Me.txtSupplierName = New System.Windows.Forms.TextBox()
        Me.txtTOP = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSVM = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(903, 50)
        Me.Label5.TabIndex = 42
        Me.Label5.Tag = "25"
        Me.Label5.Text = "Planning"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.txtPONo)
        Me.Panel1.Controls.Add(Me.btnView)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtPINo)
        Me.Panel1.Controls.Add(Me.dtERD)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dtSD)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.dtPODate)
        Me.Panel1.Controls.Add(Me.txtSupplierName)
        Me.Panel1.Controls.Add(Me.txtTOP)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtSVM)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(903, 128)
        Me.Panel1.TabIndex = 64
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(799, 94)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 63
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "PO No"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(637, 93)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 61
        Me.btnAdd.Tag = "25"
        Me.btnAdd.Text = "Update PO"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtPONo
        '
        Me.txtPONo.Enabled = False
        Me.txtPONo.Location = New System.Drawing.Point(121, 18)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.Size = New System.Drawing.Size(188, 20)
        Me.txtPONo.TabIndex = 6
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(718, 93)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 62
        Me.btnView.Text = "Input BPB"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "PI No"
        '
        'txtPINo
        '
        Me.txtPINo.Enabled = False
        Me.txtPINo.Location = New System.Drawing.Point(121, 44)
        Me.txtPINo.Name = "txtPINo"
        Me.txtPINo.Size = New System.Drawing.Size(188, 20)
        Me.txtPINo.TabIndex = 8
        '
        'dtERD
        '
        Me.dtERD.Location = New System.Drawing.Point(443, 93)
        Me.dtERD.Name = "dtERD"
        Me.dtERD.Size = New System.Drawing.Size(188, 20)
        Me.dtERD.TabIndex = 39
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "PO Date"
        '
        'dtSD
        '
        Me.dtSD.Location = New System.Drawing.Point(443, 43)
        Me.dtSD.Name = "dtSD"
        Me.dtSD.Size = New System.Drawing.Size(188, 20)
        Me.dtSD.TabIndex = 38
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Supplier Name"
        '
        'dtPODate
        '
        Me.dtPODate.Location = New System.Drawing.Point(121, 70)
        Me.dtPODate.Name = "dtPODate"
        Me.dtPODate.Size = New System.Drawing.Size(188, 20)
        Me.dtPODate.TabIndex = 37
        '
        'txtSupplierName
        '
        Me.txtSupplierName.Enabled = False
        Me.txtSupplierName.Location = New System.Drawing.Point(121, 96)
        Me.txtSupplierName.Name = "txtSupplierName"
        Me.txtSupplierName.Size = New System.Drawing.Size(188, 20)
        Me.txtSupplierName.TabIndex = 12
        '
        'txtTOP
        '
        Me.txtTOP.Enabled = False
        Me.txtTOP.Location = New System.Drawing.Point(443, 70)
        Me.txtTOP.Name = "txtTOP"
        Me.txtTOP.Size = New System.Drawing.Size(188, 20)
        Me.txtTOP.TabIndex = 36
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(322, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 13)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Ship Via/Method"
        '
        'txtSVM
        '
        Me.txtSVM.Enabled = False
        Me.txtSVM.Location = New System.Drawing.Point(443, 17)
        Me.txtSVM.Name = "txtSVM"
        Me.txtSVM.Size = New System.Drawing.Size(188, 20)
        Me.txtSVM.TabIndex = 34
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(322, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 13)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Shipping Date"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(322, 99)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(118, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Expected Receipt Date"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(322, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 13)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Term Of Payment"
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 178)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(903, 107)
        Me.dgv.TabIndex = 65
        '
        'FrmPlaning
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 285)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Name = "FrmPlaning"
        Me.Text = "FrmRMPlaning"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtPONo As TextBox
    Friend WithEvents btnView As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPINo As TextBox
    Friend WithEvents dtERD As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents dtSD As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents dtPODate As DateTimePicker
    Friend WithEvents txtSupplierName As TextBox
    Friend WithEvents txtTOP As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtSVM As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents dgv As DataGridView
    Friend WithEvents btnRefresh As Button
End Class
