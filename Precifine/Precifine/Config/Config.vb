Public Class Config

    Private Sub ReferencesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReferencesToolStripMenuItem.Click
        ReferredBy.Show()
    End Sub

    Private Sub UsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsersToolStripMenuItem.Click
        Users.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
        Users.MdiParent = Me
        ListCustomers.MdiParent = Me
        ReferredBy.MdiParent = Me
        Userdetails.MdiParent = Me
        ReferredBydetails.MdiParent = Me
        Signatories.MdiParent = Me
        Signatoriesdetails.MdiParent = Me
        AccountBook.MdiParent = Me
        AccountBookdetails.MdiParent = Me
        Tax.MdiParent = Me
        Taxdetails.MdiParent = Me
        Units.MdiParent = Me
        UnitsDetails.MdiParent = Me
        CompanyYears.MdiParent = Me
        CompanyYearsdetails.MdiParent = Me
        Assemblers.MdiParent = Me
        Assemblersdetails.MdiParent = Me
        Suppliers.MdiParent = Me
        AssemblyRates.MdiParent = Me
        AssemblyRatesdetails.MdiParent = Me
        Items.MdiParent = Me
        Itemaddsub.MdiParent = Me
        Itemsel.MdiParent = Me
        ItemProperties.MdiParent = Me
        ItemPropertiesdetails.MdiParent = Me
        Labelling.MdiParent = Me
    End Sub

    Private Sub CustomersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersToolStripMenuItem.Click
        ListCustomers.Show()
    End Sub

    Private Sub SignatoriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SignatoriesToolStripMenuItem.Click
        Signatories.Show()
    End Sub

    Private Sub AccountBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountBookToolStripMenuItem.Click
        AccountBook.Show()
    End Sub

    Private Sub TaxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaxToolStripMenuItem.Click
        Tax.Show()
    End Sub

    Private Sub UnitsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnitsToolStripMenuItem.Click
        Units.Show()
    End Sub

    Private Sub AssemblersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssemblersToolStripMenuItem.Click
        Assemblers.Show()
    End Sub

    Private Sub YearsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YearsToolStripMenuItem.Click
        CompanyYears.Show()
    End Sub

    Private Sub SuppliersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuppliersToolStripMenuItem.Click
        Suppliers.Show()
    End Sub

    Private Sub AssemblyRatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssemblyRatesToolStripMenuItem.Click
        AssemblyRates.Show()
    End Sub

    Private Sub ItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemsToolStripMenuItem.Click
        Items.Show()
    End Sub

    Private Sub ItemPropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemPropertiesToolStripMenuItem.Click
        ItemProperties.Show()
    End Sub

    Private Sub LabellingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabellingToolStripMenuItem.Click
        Labelling.Show()
    End Sub
End Class