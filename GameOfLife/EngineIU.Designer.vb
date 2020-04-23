<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EngineIU
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EngineIU))
        Me.picLife = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenInputFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveInputToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveGridAsImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.goBtn = New System.Windows.Forms.ToolStripButton()
        Me.stopBtn = New System.Windows.Forms.ToolStripButton()
        Me.clearBtn = New System.Windows.Forms.ToolStripButton()
        Me.restoreBtn = New System.Windows.Forms.ToolStripButton()
        Me.lblGenerations = New System.Windows.Forms.ToolStripLabel()
        Me.lblStatus = New System.Windows.Forms.ToolStripLabel()
        Me.tmrLife = New System.Windows.Forms.Timer(Me.components)
        Me.SizeInfoLbl = New System.Windows.Forms.Label()
        Me.widthTxtBx = New System.Windows.Forms.TextBox()
        Me.heightTxtBx = New System.Windows.Forms.TextBox()
        Me.setNewSizeBtn = New System.Windows.Forms.Button()
        CType(Me.picLife, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'picLife
        '
        Me.picLife.Location = New System.Drawing.Point(134, 52)
        Me.picLife.Name = "picLife"
        Me.picLife.Size = New System.Drawing.Size(439, 324)
        Me.picLife.TabIndex = 0
        Me.picLife.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.OpenInputFileToolStripMenuItem, Me.SaveInputToolStripMenuItem, Me.SaveGridAsImageToolStripMenuItem, Me.OptionToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(857, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(112, 20)
        Me.ToolStripMenuItem1.Text = "Generation Speed"
        '
        'OpenInputFileToolStripMenuItem
        '
        Me.OpenInputFileToolStripMenuItem.Name = "OpenInputFileToolStripMenuItem"
        Me.OpenInputFileToolStripMenuItem.Size = New System.Drawing.Size(100, 20)
        Me.OpenInputFileToolStripMenuItem.Text = "Open Input File"
        '
        'SaveInputToolStripMenuItem
        '
        Me.SaveInputToolStripMenuItem.Name = "SaveInputToolStripMenuItem"
        Me.SaveInputToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.SaveInputToolStripMenuItem.Text = "Save Input"
        '
        'SaveGridAsImageToolStripMenuItem
        '
        Me.SaveGridAsImageToolStripMenuItem.Name = "SaveGridAsImageToolStripMenuItem"
        Me.SaveGridAsImageToolStripMenuItem.Size = New System.Drawing.Size(120, 20)
        Me.SaveGridAsImageToolStripMenuItem.Text = "Save Grid As Image"
        '
        'OptionToolStripMenuItem
        '
        Me.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem"
        Me.OptionToolStripMenuItem.Size = New System.Drawing.Size(78, 20)
        Me.OptionToolStripMenuItem.Text = "Game rules"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.goBtn, Me.stopBtn, Me.clearBtn, Me.restoreBtn, Me.lblGenerations, Me.lblStatus})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(857, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'goBtn
        '
        Me.goBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.goBtn.Image = CType(resources.GetObject("goBtn.Image"), System.Drawing.Image)
        Me.goBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.goBtn.Name = "goBtn"
        Me.goBtn.Size = New System.Drawing.Size(23, 22)
        Me.goBtn.Text = "Go"
        '
        'stopBtn
        '
        Me.stopBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.stopBtn.Image = CType(resources.GetObject("stopBtn.Image"), System.Drawing.Image)
        Me.stopBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.stopBtn.Name = "stopBtn"
        Me.stopBtn.Size = New System.Drawing.Size(23, 22)
        Me.stopBtn.Text = "Stop"
        '
        'clearBtn
        '
        Me.clearBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.clearBtn.Image = CType(resources.GetObject("clearBtn.Image"), System.Drawing.Image)
        Me.clearBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.clearBtn.Name = "clearBtn"
        Me.clearBtn.Size = New System.Drawing.Size(23, 22)
        Me.clearBtn.Text = "Clear"
        '
        'restoreBtn
        '
        Me.restoreBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.restoreBtn.Image = CType(resources.GetObject("restoreBtn.Image"), System.Drawing.Image)
        Me.restoreBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.restoreBtn.Name = "restoreBtn"
        Me.restoreBtn.Size = New System.Drawing.Size(23, 22)
        Me.restoreBtn.Text = "Restore input"
        '
        'lblGenerations
        '
        Me.lblGenerations.Name = "lblGenerations"
        Me.lblGenerations.Size = New System.Drawing.Size(70, 22)
        Me.lblGenerations.Text = "Generations"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 22)
        Me.lblStatus.Text = "Status"
        '
        'tmrLife
        '
        Me.tmrLife.Interval = 500
        '
        'SizeInfoLbl
        '
        Me.SizeInfoLbl.AutoSize = True
        Me.SizeInfoLbl.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SizeInfoLbl.Location = New System.Drawing.Point(12, 408)
        Me.SizeInfoLbl.Name = "SizeInfoLbl"
        Me.SizeInfoLbl.Size = New System.Drawing.Size(104, 16)
        Me.SizeInfoLbl.TabIndex = 3
        Me.SizeInfoLbl.Text = "Grid new size : "
        '
        'widthTxtBx
        '
        Me.widthTxtBx.Location = New System.Drawing.Point(118, 407)
        Me.widthTxtBx.Name = "widthTxtBx"
        Me.widthTxtBx.Size = New System.Drawing.Size(42, 20)
        Me.widthTxtBx.TabIndex = 4
        Me.widthTxtBx.Text = "30"
        '
        'heightTxtBx
        '
        Me.heightTxtBx.Location = New System.Drawing.Point(178, 407)
        Me.heightTxtBx.Name = "heightTxtBx"
        Me.heightTxtBx.Size = New System.Drawing.Size(42, 20)
        Me.heightTxtBx.TabIndex = 5
        Me.heightTxtBx.Text = "30"
        '
        'setNewSizeBtn
        '
        Me.setNewSizeBtn.AutoSize = True
        Me.setNewSizeBtn.Location = New System.Drawing.Point(243, 404)
        Me.setNewSizeBtn.Name = "setNewSizeBtn"
        Me.setNewSizeBtn.Size = New System.Drawing.Size(79, 23)
        Me.setNewSizeBtn.TabIndex = 6
        Me.setNewSizeBtn.Text = "Apply"
        Me.setNewSizeBtn.UseVisualStyleBackColor = True
        '
        'EngineIU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 452)
        Me.Controls.Add(Me.setNewSizeBtn)
        Me.Controls.Add(Me.heightTxtBx)
        Me.Controls.Add(Me.widthTxtBx)
        Me.Controls.Add(Me.SizeInfoLbl)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.picLife)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "EngineIU"
        Me.Text = "Gaming space"
        CType(Me.picLife, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picLife As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OpenInputFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveInputToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveGridAsImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OptionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents goBtn As ToolStripButton
    Friend WithEvents stopBtn As ToolStripButton
    Friend WithEvents clearBtn As ToolStripButton
    Friend WithEvents restoreBtn As ToolStripButton
    Friend WithEvents lblGenerations As ToolStripLabel
    Friend WithEvents lblStatus As ToolStripLabel
    Friend WithEvents tmrLife As Timer
    Friend WithEvents SizeInfoLbl As Label
    Friend WithEvents widthTxtBx As TextBox
    Friend WithEvents heightTxtBx As TextBox
    Friend WithEvents setNewSizeBtn As Button
End Class
