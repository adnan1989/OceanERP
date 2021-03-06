﻿Public Class MenuUtama
#Region "Function"
    Sub HideMenuMaster()
        'menu master
        menuMaster.Visible = False
        menuDestination.Visible = False
        menuUser.Visible = False
        menuBank.Visible = False
        menuFabric.Visible = False
        menuTOP.Visible = False
        menuColor.Visible = False
        menuUtilities.Visible = False
        menuGroupSales.Visible = False
        menuCustomer.Visible = False
        menuSupplier.Visible = False
        menuYarn.Visible = False
        menuBankAccount.Visible = False
        menuSeason.Visible = False
        menuCOA.Visible = False
        menuUnit.Visible = False
        menuBrandYarn.Visible = False
        menuStyle.Visible = False
        menuRawMaterial.Visible = False
        menuBOM.Visible = False
        'end
    End Sub
    Sub HideMenuTransaction()
        'menu transaksi
        menuTransaksi.Visible = False
        menuProformaInvoice.Visible = False
        menuPO.Visible = False
        'end
    End Sub
    Sub HideAllMenu()
        'menu setting
        menuPermission.Visible = False
        'end
        HideMenuMaster()
        HideMenuTransaction()
    End Sub
    Sub CheckPermissionMenuMaster(menuID As Integer)
        'menu master
        If menuID = menuDestination.Tag Then
            menuMaster.Visible = True
            menuDestination.Visible = True
        End If
        If menuID = menuUser.Tag Then
            menuMaster.Visible = True
            menuUser.Visible = True
        End If
        If menuID = menuBank.Tag Then
            menuMaster.Visible = True
            menuBank.Visible = True
        End If
        If menuID = menuFabric.Tag Then
            menuMaster.Visible = True
            menuFabric.Visible = True
        End If
        If menuID = menuTOP.Tag Then
            menuMaster.Visible = True
            menuTOP.Visible = True
        End If
        If menuID = menuColor.Tag Then
            menuMaster.Visible = True
            menuColor.Visible = True
        End If
        If menuID = menuUtilities.Tag Then
            menuMaster.Visible = True
            menuUtilities.Visible = True
        End If
        If menuID = menuGroupSales.Tag Then
            menuMaster.Visible = True
            menuGroupSales.Visible = True
        End If
        If menuID = menuCustomer.Tag Then
            menuMaster.Visible = True
            menuCustomer.Visible = True
        End If
        If menuID = menuSupplier.Tag Then
            menuMaster.Visible = True
            menuSupplier.Visible = True
        End If
        If menuID = menuYarn.Tag Then
            menuMaster.Visible = True
            menuYarn.Visible = True
        End If
        If menuID = menuBankAccount.Tag Then
            menuMaster.Visible = True
            menuBankAccount.Visible = True
        End If
        If menuID = menuSeason.Tag Then
            menuMaster.Visible = True
            menuSeason.Visible = True
        End If
        If menuID = menuCOA.Tag Then
            menuMaster.Visible = True
            menuCOA.Visible = True
        End If
        If menuID = menuUnit.Tag Then
            menuMaster.Visible = True
            menuUnit.Visible = True
        End If
        If menuID = menuBrandYarn.Tag Then
            menuMaster.Visible = True
            menuBrandYarn.Visible = True
        End If
        If menuID = menuStyle.Tag Then
            menuMaster.Visible = True
            menuStyle.Visible = True
        End If
        If menuID = menuRawMaterial.Tag Then
            menuMaster.Visible = True
            menuRawMaterial.Visible = True
        End If

        If menuID = menuBOM.Tag Then
            menuMaster.Visible = True
            menuBOM.Visible = True
        End If
        'end
    End Sub
    Sub CheckPermissionMenuTrans(menuID As Integer)
        If menuID = menuProformaInvoice.Tag Then
            menuTransaksi.Visible = True
            menuProformaInvoice.Visible = True
        End If

        If menuID = menuPO.Tag Then
            menuTransaksi.Visible = True
            menuPO.Visible = True
        End If
    End Sub
    Sub CheckPermissionMenu(menuID As Integer)
        If userID = 1 Then menuPermission.Visible = True
        CheckPermissionMenuMaster(menuID)
        CheckPermissionMenuTrans(menuID)
    End Sub
#End Region

#Region "Menu Setting"
    Private Sub menuHakAkses_Click(sender As Object, e As EventArgs) Handles menuPermission.Click
        Dim frmPermission As New FrmListPermission
        frmPermission.MdiParent = Me
        'frmPermission.WindowState = FormWindowState.Maximized
        frmPermission.Show()
    End Sub
    Private Sub menuChangePassword_Click(sender As Object, e As EventArgs) Handles menuChangePassword.Click
        Dim frm As New FrmChangePassword
        frm.MdiParent = Me
        frm.Show()
    End Sub
#End Region

#Region "Menu Master"
    Private Sub menuDestination_Click(sender As Object, e As EventArgs) Handles menuDestination.Click
        Dim frmDest As New FrmDestination
        frmDest.MdiParent = Me
        'frmDest.WindowState = FormWindowState.Maximized
        frmDest.Show()
    End Sub
    Private Sub menuBank_Click(sender As Object, e As EventArgs) Handles menuBank.Click
        Dim frmBank As New FrmSettingBank
        frmBank.MdiParent = Me
        frmBank.Show()
    End Sub
    Private Sub menuUser_Click(sender As Object, e As EventArgs) Handles menuUser.Click
        Dim frm As New FrmListUser
        'frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub menuFabric_Click(sender As Object, e As EventArgs) Handles menuFabric.Click
        Dim frm As New FrmFabric
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub menuTOP_Click(sender As Object, e As EventArgs) Handles menuTOP.Click
        Dim frm As New FrmTermOfPayment
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub menuColor_Click(sender As Object, e As EventArgs) Handles menuColor.Click
        Dim frm As New FrmColors
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub menuUtilities_Click(sender As Object, e As EventArgs) Handles menuUtilities.Click
        Dim frm As New FrmUtilities
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub menuGroupSales_Click(sender As Object, e As EventArgs) Handles menuGroupSales.Click
        Dim frm As New FrmGroupSales
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub menuCustomer_Click(sender As Object, e As EventArgs) Handles menuCustomer.Click
        Dim frm As New FrmCustomer
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub menuSupplier_Click(sender As Object, e As EventArgs) Handles menuSupplier.Click
        Dim frm As New FrmSupplier
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub menuYarn_Click(sender As Object, e As EventArgs) Handles menuYarn.Click
        Dim frm As New FrmYarn
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub menuBankAccount_Click(sender As Object, e As EventArgs) Handles menuBankAccount.Click
        Dim frm As New FrmBankAccount
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub menuSeason_Click(sender As Object, e As EventArgs) Handles menuSeason.Click
        Dim frm As New FrmSeason
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub menuCOA_Click(sender As Object, e As EventArgs) Handles menuCOA.Click
        Dim frm As New FrmCOA
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub menuUnit_Click(sender As Object, e As EventArgs) Handles menuUnit.Click
        Dim frm As New FrmUnit
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub menuBrandYarn_Click(sender As Object, e As EventArgs) Handles menuBrandYarn.Click
        Dim frm As FrmBrandYarn = New FrmBrandYarn
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub menuStyle_Click(sender As Object, e As EventArgs) Handles menuStyle.Click
        Dim frm As FrmStyle = New FrmStyle
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub menuRawMaterial_Click(sender As Object, e As EventArgs) Handles menuRawMaterial.Click
        Dim frm As FrmRawMaterial = New FrmRawMaterial
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub menuBOM_Click(sender As Object, e As EventArgs) Handles menuBOM.Click
        Dim frm As FrmListBOM = New FrmListBOM
        frm.MdiParent = Me
        frm.Show()
    End Sub
#End Region

#Region "Menu Transaction"
    Private Sub menuProformaInvoice_Click(sender As Object, e As EventArgs) Handles menuProformaInvoice.Click
        Dim frm As FrmListPI = New FrmListPI
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub
    Private Sub menuPO_Click(sender As Object, e As EventArgs) Handles menuPO.Click
        Dim frm As FrmListPurchaseOrder = New FrmListPurchaseOrder
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub
#End Region

#Region "Other"
    Private Sub MenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HideAllMenu()
        If userID <> 0 Then
            Dim roleBFC As ClsPermission = New ClsPermission
            Dim listRole As New List(Of RoleDModel)
            listRole = roleBFC.RetrieveDetails(roleIDUser)
            For Each list As RoleDModel In listRole
                CheckPermissionMenu(list.MenuID)
            Next
            toltipUserName.Text = userName
            toltipTanggal.Text = Format(Now, "dd-MM-yyyy")
            toltipIP.Text = stringIPUser
            toltipCopyRight.Text = "Tiar © All Rights Reserved."
        End If
    End Sub


    Private Sub MenuUtama_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    'Private Sub MenuUtama_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
    '    HideAllMenu()
    '    If userID <> 0 Then
    '        Dim roleBFC As ClsPermission = New ClsPermission
    '        Dim listRole As New List(Of RoleDModel)
    '        listRole = roleBFC.RetrieveDetails(roleIDUser)
    '        For Each list As RoleDModel In listRole
    '            CheckPermissionMenu(list.MenuID)
    '        Next
    '        toltipUserName.Text = userName
    '        toltipTanggal.Text = Format(Now, "dd-MM-yyyy")
    '        toltipIP.Text = stringIPUser
    '        toltipCopyRight.Text = copyRight
    '    End If
    'End Sub
    Private Sub menuKeluar_Click(sender As Object, e As EventArgs) Handles menuKeluar.Click
        Dim result As DialogResult = MsgBoxQuestionExit()
        If result = MsgBoxResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub menuSVM_Click(sender As Object, e As EventArgs) Handles menuSVM.Click
        Dim frm As FrmShipViaMethod = New FrmShipViaMethod
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BonOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BonOrderToolStripMenuItem.Click
        Dim frm As FrmListBO = New FrmListBO
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub RawMAterialPlaningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawMAterialPlaningToolStripMenuItem.Click
        Dim frm As FrmPlaning = New FrmPlaning
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.Show()

    End Sub

    Private Sub ReceiptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceiptToolStripMenuItem.Click
        Dim frm As FrmListBPB = New FrmListBPB
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub
#End Region
End Class
