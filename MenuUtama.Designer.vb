﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MenuUtama
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuUtama))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.toltipUserName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toltipTanggal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toltipIP = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.menuSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuChangePassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuPermission = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuDestination = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuBank = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFabric = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuTOP = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuColor = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuUtilities = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuGroupSales = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuTransaksi = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuKeluar = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCustomer = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSupplier = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toltipUserName, Me.ToolStripStatusLabel2, Me.toltipTanggal, Me.ToolStripStatusLabel3, Me.toltipIP})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 452)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1063, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'toltipUserName
        '
        Me.toltipUserName.Name = "toltipUserName"
        Me.toltipUserName.Size = New System.Drawing.Size(62, 17)
        Me.toltipUserName.Text = "UserName"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabel2.Text = "||"
        '
        'toltipTanggal
        '
        Me.toltipTanggal.Name = "toltipTanggal"
        Me.toltipTanggal.Size = New System.Drawing.Size(47, 17)
        Me.toltipTanggal.Text = "tanggal"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabel3.Text = "||"
        '
        'toltipIP
        '
        Me.toltipIP.Name = "toltipIP"
        Me.toltipIP.Size = New System.Drawing.Size(17, 17)
        Me.toltipIP.Text = "IP"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuSetting, Me.menuMaster, Me.menuTransaksi, Me.menuKeluar})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1063, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'menuSetting
        '
        Me.menuSetting.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuChangePassword, Me.menuPermission})
        Me.menuSetting.Name = "menuSetting"
        Me.menuSetting.Size = New System.Drawing.Size(61, 20)
        Me.menuSetting.Text = "Settings"
        '
        'menuChangePassword
        '
        Me.menuChangePassword.Name = "menuChangePassword"
        Me.menuChangePassword.Size = New System.Drawing.Size(168, 22)
        Me.menuChangePassword.Text = "Change Password"
        '
        'menuPermission
        '
        Me.menuPermission.Name = "menuPermission"
        Me.menuPermission.Size = New System.Drawing.Size(168, 22)
        Me.menuPermission.Tag = "1"
        Me.menuPermission.Text = "Permission"
        '
        'menuMaster
        '
        Me.menuMaster.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuUser, Me.menuDestination, Me.menuBank, Me.menuFabric, Me.menuTOP, Me.menuColor, Me.menuUtilities, Me.menuGroupSales, Me.menuCustomer, Me.menuSupplier})
        Me.menuMaster.Name = "menuMaster"
        Me.menuMaster.Size = New System.Drawing.Size(60, 20)
        Me.menuMaster.Text = "Masters"
        '
        'menuUser
        '
        Me.menuUser.Name = "menuUser"
        Me.menuUser.Size = New System.Drawing.Size(167, 22)
        Me.menuUser.Tag = "2"
        Me.menuUser.Text = "User"
        '
        'menuDestination
        '
        Me.menuDestination.Name = "menuDestination"
        Me.menuDestination.Size = New System.Drawing.Size(167, 22)
        Me.menuDestination.Tag = "3"
        Me.menuDestination.Text = "Destination"
        '
        'menuBank
        '
        Me.menuBank.Name = "menuBank"
        Me.menuBank.Size = New System.Drawing.Size(167, 22)
        Me.menuBank.Tag = "4"
        Me.menuBank.Text = "Setting Bank"
        '
        'menuFabric
        '
        Me.menuFabric.Name = "menuFabric"
        Me.menuFabric.Size = New System.Drawing.Size(167, 22)
        Me.menuFabric.Tag = "5"
        Me.menuFabric.Text = "Fabric"
        '
        'menuTOP
        '
        Me.menuTOP.Name = "menuTOP"
        Me.menuTOP.Size = New System.Drawing.Size(167, 22)
        Me.menuTOP.Tag = "6"
        Me.menuTOP.Text = "Term Of Payment"
        '
        'menuColor
        '
        Me.menuColor.Name = "menuColor"
        Me.menuColor.Size = New System.Drawing.Size(167, 22)
        Me.menuColor.Tag = "7"
        Me.menuColor.Text = "Color"
        '
        'menuUtilities
        '
        Me.menuUtilities.Name = "menuUtilities"
        Me.menuUtilities.Size = New System.Drawing.Size(167, 22)
        Me.menuUtilities.Tag = "8"
        Me.menuUtilities.Text = "Utilities"
        '
        'menuGroupSales
        '
        Me.menuGroupSales.Name = "menuGroupSales"
        Me.menuGroupSales.Size = New System.Drawing.Size(167, 22)
        Me.menuGroupSales.Tag = "9"
        Me.menuGroupSales.Text = "Group Sales"
        '
        'menuTransaksi
        '
        Me.menuTransaksi.Name = "menuTransaksi"
        Me.menuTransaksi.Size = New System.Drawing.Size(85, 20)
        Me.menuTransaksi.Text = "Transactions"
        '
        'menuKeluar
        '
        Me.menuKeluar.Name = "menuKeluar"
        Me.menuKeluar.Size = New System.Drawing.Size(37, 20)
        Me.menuKeluar.Text = "Exit"
        '
        'menuCustomer
        '
        Me.menuCustomer.Name = "menuCustomer"
        Me.menuCustomer.Size = New System.Drawing.Size(167, 22)
        Me.menuCustomer.Tag = "10"
        Me.menuCustomer.Text = "Customer"
        '
        'menuSupplier
        '
        Me.menuSupplier.Name = "menuSupplier"
        Me.menuSupplier.Size = New System.Drawing.Size(167, 22)
        Me.menuSupplier.Tag = "11"
        Me.menuSupplier.Text = "Supplier"
        '
        'MenuUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1063, 474)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MenuUtama"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PT.Ocean Asia Industri"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents toltipUserName As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents toltipTanggal As ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents menuSetting As ToolStripMenuItem
    Friend WithEvents menuChangePassword As ToolStripMenuItem
    Friend WithEvents menuPermission As ToolStripMenuItem
    Friend WithEvents menuMaster As ToolStripMenuItem
    Friend WithEvents menuTransaksi As ToolStripMenuItem
    Friend WithEvents menuKeluar As ToolStripMenuItem
    Friend WithEvents menuDestination As ToolStripMenuItem
    Friend WithEvents menuBank As ToolStripMenuItem
    Friend WithEvents menuUser As ToolStripMenuItem
    Friend WithEvents menuFabric As ToolStripMenuItem
    Friend WithEvents menuTOP As ToolStripMenuItem
    Friend WithEvents menuColor As ToolStripMenuItem
    Friend WithEvents menuUtilities As ToolStripMenuItem
    Friend WithEvents menuGroupSales As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents toltipIP As ToolStripStatusLabel
    Friend WithEvents menuCustomer As ToolStripMenuItem
    Friend WithEvents menuSupplier As ToolStripMenuItem
End Class
