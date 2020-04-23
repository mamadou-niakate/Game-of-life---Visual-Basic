Imports System.Drawing.Drawing2D
Imports System.IO
Public Class EngineIU
    'GLOBAL VARIABLES'
    Private gameEngine As New Engine() 'objet of the Engine class that we use to work over our grid
    Dim input(gameEngine.gridSizeX, gameEngine.gridSizeY) As Boolean 'intermediary grid with the same size as the main grid in order to restore input 
    Dim generations As Integer = 0 'number of cells generation
    Dim minBirth, maxBirth, minDeath, maxDeath As New TextBox() 'Declaration of dynamics textBoxes in order to fix/change the cells generation rules
    Dim tmrSpeedTbr As New TrackBar 'declaration of a track bar to change the generation speed
    Dim tmrSpeed As New Label 'the label that contains the timer interval and shows it on the form

    'MAIN FORM LOAD EVENT HANDLER PROCEDURE
    Private Sub Form1_Load(sender As Object, e As EventArgs)
        Dim gridRows As Integer
        Dim gridColumns As Integer
        gameEngine.getSizeGrid(gridRows, gridColumns) 'get the grid size in two variables

        For i As Integer = 0 To gridRows
            For j As Integer = 0 To gridColumns
                gameEngine.setCellState(i, j, False) 'set each cell of the grid at death state
            Next
        Next
    End Sub


    'PAINT PICLIFE WITH THE GRID
    Private Sub picLife_Paint(sender As Object, e As PaintEventArgs) Handles picLife.Paint
        Dim g As Graphics = e.Graphics 'create a graphic object named g supplied in the PaintEventArgs
        g.Clear(Me.BackColor)           'set the graphic object back color to the main form back color
        g.PageUnit = GraphicsUnit.Pixel 'set the unit of measure of the page to pixel
        Dim rect As Rectangle 'declare a rectangle that will help to fill the select cell

        Dim gridRows, gridColumns As Integer
        gameEngine.getSizeGrid(gridRows, gridColumns)  'get the grid size in two variables

        'drawing the rows in the graphics object with an interval of 10 pixel between each rows
        For i As Integer = 10 To gridColumns * 10 Step 10
            g.DrawLine(Pens.Black, 0, i, gridRows * 10, i)
        Next

        ' drawing the columns in the graphics object with an interval of 10 pixel between each line columns
        For i As Integer = 10 To gridRows * 10 - 10 Step 10
            g.DrawLine(Pens.Black, i, 0, i, gridColumns * 10)
        Next

        'fill the selected cell with a black rectangle
        For i As Integer = 0 To gridRows
            For j As Integer = 0 To gridColumns
                If gameEngine.getCellState(i, j) Then
                    rect = New Rectangle(i * 10, j * 10, 10, 10) 'set the rectangle location, width and height
                    g.FillRectangle(Brushes.Black, rect) 'put the rectangle into the graphic object
                End If
            Next
        Next

        'set the grid border to black color
        For i As Integer = 0 To gridRows
            For j As Integer = 0 To gridColumns
                If (i = 0 Or j = 0 Or i = gridRows Or j = gridColumns) Then
                    rect = New Rectangle(i * 10, j * 10, 10, 10)
                    g.FillRectangle(Brushes.Black, rect)
                End If
            Next
        Next

    End Sub

    'Change a cell state when click on it
    Private Sub picLife_MouseClick(sender As Object, e As MouseEventArgs) Handles picLife.MouseClick
        If Not tmrLife.Enabled Then 'check if the generation is stoped
            'take the mouse click postions and divid each coordonate by 10 because the there're 10 pixels between each raws and colums
            Dim x As Integer = e.X \ 10
            Dim y As Integer = e.Y \ 10
            If gameEngine.getCellState(x, y) = True Then 'if the cell is alive 
                gameEngine.setCellState(x, y, False) 'it becomes death
            ElseIf gameEngine.getCellState(x, y) = False Then 'if the cell is dead 
                gameEngine.setCellState(x, y, True) 'it becomes alive
            End If
            picLife.Refresh() 'adapt the picture box that contains the grid to the new changes
        End If
    End Sub

    'copy the grid to the intermediary grid
    Sub CopyGridToInput()
        Dim gridRows, gridColumns As Integer
        gameEngine.getSizeGrid(gridRows, gridColumns) 'get the grid size in two variables

        For i As Integer = 0 To gridRows
            For j As Integer = 0 To gridColumns
                input(i, j) = gameEngine.getCellState(i, j) 'fill the intermediary grid (named input) cells with the grid cells
            Next
        Next
    End Sub

    'copy the intermediary grid to the grid
    Sub CopyInputToGrid()
        Dim gridRows, gridColumns As Integer
        gameEngine.getSizeGrid(gridRows, gridColumns) 'get the grid size in two variables

        For i As Integer = 0 To gridRows
            For j As Integer = 0 To gridColumns
                gameEngine.setCellState(i, j, input(i, j)) 'fill the grid cells with the intermediary grid (named input) cells
            Next
        Next
    End Sub

    'start cells generation by clicking on Go button
    Private Sub goBtn_Click(sender As Object, e As EventArgs) Handles goBtn.Click
        If generations = 0 Then 'if there's not generation
            CopyGridToInput() 'call of the procedure that copies the grid to the intermediary grid
        End If
        tmrLife.Enabled = True 'make enable the timer (i.e start generating
        lblStatus.Text = "Animating"
    End Sub

    'stop cells generating by clicking on Stop button
    Private Sub stopBtn_Click(sender As Object, e As EventArgs) Handles stopBtn.Click
        tmrLife.Enabled = False 'stop the timer (i.e stop the generation)
        lblStatus.Text = "Stopped"
    End Sub

    'clear the grid by click on Clear button
    Private Sub clearBtn_Click(sender As Object, e As EventArgs) Handles clearBtn.Click
        Dim gridRows, gridColumns As Integer
        gameEngine.getSizeGrid(gridRows, gridColumns) 'get the grid size in two variables

        If Not tmrLife.Enabled Then
            For i As Integer = 0 To gridRows
                For j As Integer = 0 To gridColumns
                    gameEngine.setCellState(i, j, False) 'set each cell of the grid at death state 
                Next
            Next
            generations = 0
            lblGenerations.Text = "Generations: " + Str(generations) 'put the string representaion of the numbers of generetion in a label
            picLife.Refresh() 'adapt the picture box that contains the grid to the new changes
        End If
    End Sub

    'restore the previous input by clicking on the Restore button
    Private Sub restoreBtn_Click(sender As Object, e As EventArgs) Handles restoreBtn.Click
        If Not tmrLife.Enabled Then
            generations = 0
            lblGenerations.Text = "Generations: " + Str(generations)
            CopyInputToGrid() 'call of the procedure that copies the intermediary grid that contains the input to the grid
            picLife.Refresh() 'adapt the picture box that contains the grid to the new changes
        End If
    End Sub

    'Exiting the application
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If MessageBox.Show("Are you sure to exit?", "Application", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    'Return the grid as an Bitmap object which consist of the pixel data for the graphical image and attributs
    Function BitmapFromGrid() As Bitmap
        Dim gridRows, gridColumns As Integer
        gameEngine.getSizeGrid(gridRows, gridColumns) 'get the grid size in two variables

        Dim bmp As Bitmap = New Bitmap(640, 640) 'initialize a new instance of Bitmap class with the specied size
        Dim g As Graphics = Graphics.FromImage(bmp) 'Create graphics object for alteration(Creates a new Graphics from the specified image)
        Dim rect As Rectangle   'declare a rectangle that will help to fill the select cell
        For i As Integer = 0 To gridRows
            For j As Integer = 0 To gridColumns
                If gameEngine.getCellState(i, j) Then
                    rect = New Rectangle(i * 10, j * 10, 10, 10)
                    g.FillRectangle(Brushes.Black, rect)
                End If
            Next
        Next
        Return bmp 'return a Bitmap object that used to work with the graphic object as an image defined by pixel data
    End Function

    'Exporting the grids as an image
    Private Sub SaveGridAsImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveGridAsImageToolStripMenuItem.Click
        If Not tmrLife.Enabled Then
            Dim sd As SaveFileDialog = New SaveFileDialog() 'declare an object of the class SaveFileDialog that promps user to select a location for saving a file
            sd.Title = "Save The Image"
            sd.Filter = "Windows Bitmap|*.bmp" 'permit to set /get the current file name filter string whick determines the choices that appear in the "Save a file type" or "File of type" box in the dialog box
            Dim b As Bitmap 'declare a Bitmap reference
            If sd.ShowDialog = Windows.Forms.DialogResult.OK Then
                b = BitmapFromGrid() 'put the grid bitmaped as an image in a Bitmap object name b
                b.Save(sd.FileName) 'save the image through it name
            End If
        End If
    End Sub

    'Produce the grid to string and return its copy
    Function ProduceGridString() As String
        Dim gridRows, gridColumns As Integer
        gameEngine.getSizeGrid(gridRows, gridColumns) 'get the grid size in two variables

        Dim s As String = ""
        For i As Integer = 0 To gridRows
            For j As Integer = 0 To gridColumns
                If gameEngine.getCellState(i, j) = False Then ' if  cell is dead
                    s = s + Trim(Str(0)) 'add the cell copy to the string without space at right nor at left
                Else  'if  cell is alive
                    s = s + Trim(Str(1)) 'add the cell copy to the string without space at right nor at left
                End If
            Next
        Next
        Return s 'return the copy of the grid
    End Function

    'convert a string to a grid normal
    Sub GridFromString(ByVal s As String)
        Dim gridRows As Integer
        Dim gridColumns As Integer
        gameEngine.getSizeGrid(gridRows, gridColumns) 'get the grid size in two variables

        Dim count As Integer = 0
        For i As Integer = 0 To gridRows
            For j As Integer = 0 To gridColumns
                If s.Substring(count, 1) = "0" Then 'if the a character of the string is 0
                    gameEngine.setCellState(i, j, False) 'put the cell to death state
                Else 'if the a character of the string is 1
                    gameEngine.setCellState(i, j, True) 'make alive the cell 
                End If
                count += 1 'increment the count in order to cross the all the string character
            Next
        Next
    End Sub

    'Saving (export) the grid in a file
    Private Sub SaveInputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveInputToolStripMenuItem.Click
        If Not tmrLife.Enabled Then
            Dim sd As SaveFileDialog = New SaveFileDialog()  'declare an object of the class SaveFileDialog that promps user to select a location for saving a file
            sd.Title = "Save The Input"
            sd.Filter = "Life Input File|*.lif" 'permit to set /get the current file name filter string whick determines the choices that appear in the "Save a file type" or "File of type" box in the dialog box
            If sd.ShowDialog = Windows.Forms.DialogResult.OK Then
                File.WriteAllText(sd.FileName, ProduceGridString()) 'Creates a new file, write the contents to the file, and then closes the file. If the target file already exists, it is overwritten.
            End If
        End If
    End Sub

    'Importing a file as grid
    Private Sub OpenInputFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenInputFileToolStripMenuItem.Click
        If Not tmrLife.Enabled Then
            Dim od As OpenFileDialog = New OpenFileDialog() ' create an open file dialog in order to import a file
            od.Title = "Open The Input"
            od.Filter = "Life Input File|*.lif"
            Dim inpt As String = ""
            If od.ShowDialog = Windows.Forms.DialogResult.OK Then
                inpt = File.ReadAllText(od.FileName) 'open a file read each line of the file and put it in a string variable
                GridFromString(inpt) 'convert the string to a grig
                generations = 0
                lblGenerations.Text = "Generations: " + Str(generations)
                picLife.Refresh()
            End If
        End If
    End Sub

    'create a track bar when clic on the menu strip item 'Speed'
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        tmrSpeedTbr.Height = 200 'the track bar heigh
        tmrSpeedTbr.Orientation = Orientation.Vertical 'we steer the track bar verticaly
        tmrSpeedTbr.Dock = DockStyle.None 'we don't dock the track bar in order to fixe its location ourself
        tmrSpeedTbr.Minimum = 100 'the minimum value that the track bar takes 
        tmrSpeedTbr.Maximum = 1000 'the maximum value that the track bar takes
        tmrSpeedTbr.Value = 100 'the current value of track bar takes
        tmrSpeedTbr.TickFrequency = 100 'the value that the track bar takes more at its every tick 
        tmrSpeedTbr.TickStyle = TickStyle.BottomRight 'the row of the track bar will at its bottons and the graduation at right
        Me.Controls.Add(tmrSpeedTbr) 'add the track bar to the main Form
        tmrSpeedTbr.Location = New Point(picLife.Width / 6, 141) 'locate it to the left of the picture box

        tmrLife.Interval = tmrSpeedTbr.Value 'the timer interval takes the value of the track bar
        tmrSpeed.Text = "Speed : " & tmrLife.Interval 'put the timer interval in a label to show it
        tmrSpeed.Location = New Point(tmrSpeedTbr.Location.X - 72, tmrSpeedTbr.Location.Y - 20) 'locate the label that show the timer current value
        Me.Controls.Add(tmrSpeed)

        AddHandler tmrSpeedTbr.Scroll, AddressOf tmrSpeedTbr_Scroll
    End Sub

    'change the cells generation speed through a dynamic track bar
    Private Sub tmrSpeedTbr_Scroll(sender As Object, e As EventArgs)
        tmrLife.Interval = tmrSpeedTbr.Value 'the timer interval takes the value of the track bar
        tmrSpeed.Text = "Speed : " & tmrLife.Interval 'put the timer interval in a label to show it
    End Sub

    'Make cells generation in an intervalle of time with a timer
    Private Sub tmrLife_Tick(sender As Object, e As EventArgs) Handles tmrLife.Tick
        Dim aliveCells As Integer = 0
        Dim gridRows, gridColumns As Integer
        gameEngine.getSizeGrid(gridRows, gridColumns) 'get the grid size in two variables

        'count the number of alive cells so that we can stop the generation if there's no alive cell
        For i As Integer = 0 To gridRows
            For j As Integer = 0 To gridColumns
                If gameEngine.getCellState(i, j) Then
                    aliveCells += 1
                End If
            Next
        Next

        If (aliveCells > 0) Then 'continue cells generation if there's one or a lot of alive cells
            gameEngine.nextState()
            generations += 1
            lblGenerations.Text = "Generations: " + Str(generations)
            picLife.Refresh()
        Else 'stop cells generation if all the cells are dead
            tmrLife.Stop()
            lblStatus.Text = "Finished"
            generations = 0
            lblGenerations.Text = "Generations: " + Str(generations)
        End If

    End Sub

    'Creating dynamics textBoxes in order to fix/change the cells generating rules
    Private Sub OptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionToolStripMenuItem.Click
        If Not tmrLife.Enabled Then
            Dim minBirthTxt As New Label()
            minBirthTxt.Text = "Minimum birth : "
            minBirthTxt.Location = New Point(643, 52)
            Me.Controls.Add(minBirthTxt)

            'creating the minimum alive cells death text box
            minBirth.Location = New Point(minBirthTxt.Location.X + 100, minBirthTxt.Location.Y)
            minBirth.Size = New Size(50, 30)
            Me.Controls.Add(minBirth)

            Dim maxBirthTxt As New Label()
            maxBirthTxt.Text = "Maximum birth : "
            maxBirthTxt.Location = New Point(minBirthTxt.Location.X, minBirthTxt.Location.Y + 40)
            Me.Controls.Add(maxBirthTxt)

            'creating the maximum alive cells alive text box
            maxBirth.Location = New Point(minBirth.Location.X, minBirth.Location.Y + 40)
            maxBirth.Size = New Size(50, 30)
            Me.Controls.Add(maxBirth)

            Dim minDeathTxt As New Label()
            minDeathTxt.Text = "Minimum death : "
            minDeathTxt.Location = New Point(maxBirthTxt.Location.X, maxBirthTxt.Location.Y + 40)
            Me.Controls.Add(minDeathTxt)

            'creating the minimum dead cells death text box
            minDeath.Location = New Point(maxBirth.Location.X, maxBirth.Location.Y + 40)
            minDeath.Size = New Size(50, 30)
            Me.Controls.Add(minDeath)

            Dim maxDeathTxt As New Label()
            maxDeathTxt.Text = "Maximum death : "
            maxDeathTxt.Location = New Point(minDeathTxt.Location.X, minDeathTxt.Location.Y + 40)
            Me.Controls.Add(maxDeathTxt)

            'creating the maximum dead cells death text box
            maxDeath.Location = New Point(minDeath.Location.X, minDeath.Location.Y + 40)
            maxDeath.Size = New Size(50, 30)
            Me.Controls.Add(maxDeath)

            'creating the button to apply new rule
            Dim applyBtn As New Button()
            applyBtn.Text = "Apply"
            applyBtn.Location = New Point(maxDeathTxt.Location.X + 40, maxDeathTxt.Location.Y + 40)
            Me.Controls.Add(applyBtn)

            AddHandler applyBtn.Click, AddressOf applyBtn_CLICK
        End If
    End Sub

    'applying the cells generating new rule
    Public Sub applyBtn_CLICK(sender As Object, e As EventArgs)
        Dim minD, maxD, minB, maxB As Integer
        'cheick if the rules textboxes valuers are digital numbers before converting them to integer
        If IsNumeric(minDeath.Text) And IsNumeric(maxDeath.Text) And IsNumeric(minBirth.Text) And IsNumeric(maxBirth.Text) Then
            minD = CInt(minDeath.Text)
            maxD = CInt(maxDeath.Text)
            minB = CInt(minBirth.Text)
            maxB = CInt(maxBirth.Text)
        End If

        'evoid that the minimum to be more then the maximum
        If (minD > maxD) Then
            MessageBox.Show("Minimum death can't be greater than the Maximum death")
        ElseIf (minB > maxB) Then
            MessageBox.Show("Minimum birth can't be greater then the Maximum birth")
            'forbid the user to set overValue
        ElseIf maxD > 8 Or maxB > 8 Then
            MessageBox.Show("A cell can't have more than " & 8 & " neigbours")
            'forbid the user to set underValue
        ElseIf minB < 0 Or minD < 0 Or maxB < 0 Or maxD < 0 Then
            MessageBox.Show("A cell can't have less then " & 0 & " neigbours")
        Else
            gameEngine.setRule(minD, maxD, minB, maxB) 'set the new rules
            picLife.Refresh()
        End If
    End Sub

    'applying the grid new size
    Private Sub setNewSizeBtn_Click(sender As Object, e As EventArgs) Handles setNewSizeBtn.Click
        Dim gridNewWidth, gridNewHeight As Integer

        'cheick if the size textboxes valuers are digital numbers before converting them to integer
        If IsNumeric(Me.widthTxtBx.Text) And IsNumeric(Me.heightTxtBx.Text) Then
            gridNewWidth = CInt(Me.widthTxtBx.Text)
            gridNewHeight = CInt(Me.heightTxtBx.Text)
        End If

        If Not tmrLife.Enabled Then 'cheick if the cells generation is stoped before changing the grid size
            gameEngine.setSizeGrid(gridNewWidth, gridNewHeight)
            picLife.Refresh()
        End If
    End Sub
End Class
