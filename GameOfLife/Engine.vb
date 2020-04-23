Public Class Engine

    Private grid(,) As Boolean 'declaration of a 2D boolean array
    Public gridSizeX, gridSizeY As Integer 'declaration of the 2D grid size 

    Private minDeath As Integer, maxDeath As Integer 'declaration of numbers dead cells
    Private minBirth As Integer, maxBirth As Integer 'declaration of numbers alive cells

    'INITIALIZE THE VARIABLES IN A CONSTRUCTOR WITH DEFAULT VALUE OF EACH VARIABLE
    Public Sub New()
        minDeath = 2
        maxDeath = 4
        minBirth = 3
        maxBirth = 3
        gridSizeX = 43
        gridSizeY = 32
        setSizeGrid(gridSizeX, gridSizeY)
    End Sub

    'FIX THE GAME RULES
    Public Sub setRule(minDeath As Integer, maxDeath As Integer, minBirth As Integer, maxBirth As Integer)
        Me.minDeath = minDeath
        Me.maxDeath = maxDeath
        Me.minBirth = minBirth
        Me.maxBirth = maxBirth
    End Sub

    'SET THE GRID SIZE
    Public Sub setSizeGrid(ByRef n As Integer, ByRef m As Integer)
        'we first evoid the grid to exceed the pictureBox size
        If n > 43 Then
            n = 43
        End If
        If m > 32 Then
            m = 32
        End If

        grid = New Boolean(,) {}
        ReDim grid(n, m)  'SET THE GRIG SIZE
        Me.gridSizeX = n 'SET THE GRID WIDTH
        Me.gridSizeY = m 'SET THE GRID HEIGHT
    End Sub

    'RETURN THE GRID SIZE
    Public Sub getSizeGrid(ByRef n As Integer, ByRef m As Integer)
        n = gridSizeX 'initialize n by the number of rows of the grid
        m = gridSizeY 'initialize m by the number of columns of the grid
    End Sub

    'FIX THE STATE OF THE CELL AT i ROW AND j COLUMN 
    Public Sub setCellState(ByRef i As Integer, ByRef j As Integer, state As Boolean)
        'we check first if the row i or column j is not out of the grid
        If i <= gridSizeX - 1 And j <= gridSizeY - 1 Then
            grid(i, j) = state
        End If
    End Sub

    'RETURN THE STATE OF THE CELL AT i ROW AND j COLUMN
    Public Function getCellState(ByRef i As Integer, ByRef j As Integer)
        'we check if the row i or column j is not out of the grid
        If i <= gridSizeX - 1 And j <= gridSizeY - 1 Then
            Return grid(i, j) 'return True/False according to the cell state
        End If
        Return False
    End Function

    'MAKE THE NEXT CELL GENERATING
    Public Sub nextState()
        Dim gridRows As Integer
        Dim gridColumns As Integer
        getSizeGrid(gridRows, gridColumns) 'recuperate the grid size in two variables

        Dim neighbours(gridRows, gridColumns) As Byte
        For i As Integer = 0 To gridRows
            For j As Integer = 0 To gridColumns
                neighbours(i, j) = CountNeighbors(i, j)
            Next
        Next

        For i As Integer = 0 To gridRows
            For j As Integer = 0 To gridColumns
                If getCellState(i, j) = False Then 'WHEN THE CELL IS DEAD
                    ' dead cells
                    If neighbours(i, j) >= 3 And neighbours(i, j) <= maxBirth Then 'and its has 3 alive neighbours
                        ' reproduction
                        setCellState(i, j, True)  'then it becomes alive
                    End If
                Else 'WHEN THE CELL IS ALIVE
                    ' live cells
                    If neighbours(i, j) >= minDeath And neighbours(i, j) <= maxDeath Then 'if a cell has more then 3 dead neighbours 
                        ' overcrowding
                        setCellState(i, j, False)      'it dies
                    End If
                    If neighbours(i, j) < minDeath Then 'if a cell is alive and has less than 2 dead neighbours 
                        ' underpopulation
                        setCellState(i, j, False)        'it dies
                    End If
                End If
            Next
        Next
    End Sub

    'count the number of neighbors of a cell
    Public Function CountNeighbors(ByVal cellX As Integer, ByVal cellY As Integer) As Integer
        Dim count As Integer = 0
        If cellX <= gridSizeX - 1 And cellY <= gridSizeY - 1 Then  'check first that all the cells are inside of the grid
            If cellX > 0 And cellY > 0 Then
                'if both are > 0 then I can look at
                'upper-left, upper, and left cells safely
                If grid(cellX - 1, cellY - 1) Then count += 1
                If grid(cellX, cellY - 1) Then count += 1
                If grid(cellX - 1, cellY) Then count += 1
            End If
            If cellX < 63 And cellY < 63 Then
                'if both are < GridSize then I can look at
                'lower-right, right, and lower cells safely
                If grid(cellX + 1, cellY + 1) Then count += 1
                If grid(cellX, cellY + 1) Then count += 1
                If grid(cellX + 1, cellY) Then count += 1
            End If
            If cellX > 0 And cellY < 63 Then
                If grid(cellX - 1, cellY + 1) Then count += 1
            End If
            If cellX < 63 And cellY > 0 Then
                If grid(cellX + 1, cellY - 1) Then count += 1
            End If
        End If
        Return count
    End Function

End Class
