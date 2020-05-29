<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Presentacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PLogo = New System.Windows.Forms.Panel()
        Me.PBlogo = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnIngresarPresentacion = New FontAwesome.Sharp.IconButton()
        Me.PLogo.SuspendLayout()
        CType(Me.PBlogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PLogo
        '
        Me.PLogo.Controls.Add(Me.PBlogo)
        Me.PLogo.Location = New System.Drawing.Point(12, 12)
        Me.PLogo.Name = "PLogo"
        Me.PLogo.Size = New System.Drawing.Size(367, 106)
        Me.PLogo.TabIndex = 0
        '
        'PBlogo
        '
        Me.PBlogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PBlogo.Image = Global.CRUDFORMULARIO.My.Resources.Resources.logouss
        Me.PBlogo.Location = New System.Drawing.Point(0, 0)
        Me.PBlogo.Name = "PBlogo"
        Me.PBlogo.Size = New System.Drawing.Size(367, 106)
        Me.PBlogo.TabIndex = 1
        Me.PBlogo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Georgia", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(12, 175)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Integrante:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Georgia", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(66, 213)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(240, 25)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "-Piscoya Inoñan Sandra"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Georgia", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label8.Location = New System.Drawing.Point(34, 134)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(326, 25)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Desarrollo de Práctica Calificada"
        '
        'btnIngresarPresentacion
        '
        Me.btnIngresarPresentacion.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.btnIngresarPresentacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresarPresentacion.IconChar = FontAwesome.Sharp.IconChar.ChevronRight
        Me.btnIngresarPresentacion.IconColor = System.Drawing.Color.Black
        Me.btnIngresarPresentacion.IconSize = 18
        Me.btnIngresarPresentacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIngresarPresentacion.Location = New System.Drawing.Point(232, 278)
        Me.btnIngresarPresentacion.Name = "btnIngresarPresentacion"
        Me.btnIngresarPresentacion.Rotation = 0R
        Me.btnIngresarPresentacion.Size = New System.Drawing.Size(147, 32)
        Me.btnIngresarPresentacion.TabIndex = 9
        Me.btnIngresarPresentacion.Text = "INGRESAR"
        Me.btnIngresarPresentacion.UseVisualStyleBackColor = True
        '
        'Presentacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(408, 342)
        Me.Controls.Add(Me.btnIngresarPresentacion)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PLogo)
        Me.Name = "Presentacion"
        Me.Text = "Presentacion"
        Me.PLogo.ResumeLayout(False)
        CType(Me.PBlogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PLogo As Panel
    Friend WithEvents PBlogo As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnIngresarPresentacion As FontAwesome.Sharp.IconButton
End Class
