Public Class Form1
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        ' 從 TextBox 取得原始字串
        Dim originalString As String = TextBox1.Text

        ' 新增的字串
        Dim newString As String = TextBox2.Text

        ' 將原始字串轉為字串陣列
        Dim stringsToCheck As String() = originalString.Split("|"c)

        ' 檢查順序是否正確
        If Not IsOrderCorrect(stringsToCheck) Then
            ' 順序不正確，顯示錯誤信息並標註紅色
            DisplayOrderError(originalString, stringsToCheck)
            Return
        End If

        ' 順序正確，新增字串到列表中，保持字母順序
        Dim resultArray As String() = InsertIntoSortedArray(stringsToCheck, newString)

        ' 將結果輸出到 RichTextBox，不改變顏色
        DisplayInRichTextBox(resultArray)
    End Sub

    Function IsOrderCorrect(ByVal strings As String()) As Boolean
        ' 檢查字串陣列是否按照字母順序排列
        For i As Integer = 1 To strings.Length - 1
            If String.Compare(strings(i - 1), strings(i), StringComparison.Ordinal) > 0 Then
                Return False
            End If
        Next
        Return True
    End Function

    Sub DisplayOrderError(ByVal originalString As String, ByVal stringsToCheck As String())
        ' 顯示錯誤信息，標註紅色
        RichTextBox1.Clear()

        ' 第一行輸出原本的字串代碼
        RichTextBox1.AppendText(originalString)

        ' 換行
        RichTextBox1.AppendText(vbCrLf)

        ' 第二行輸出應該修改的順序，並將有修改順序的字串以紅色顏色標註
        For i As Integer = 1 To stringsToCheck.Length - 1
            If String.Compare(stringsToCheck(i - 1), stringsToCheck(i), StringComparison.Ordinal) > 0 Then
                RichTextBox1.SelectionColor = Color.Red
            Else
                RichTextBox1.SelectionColor = RichTextBox1.ForeColor
            End If

            RichTextBox1.AppendText(stringsToCheck(i - 1))
            RichTextBox1.AppendText("|")
        Next

        ' 最後一個字串
        RichTextBox1.AppendText(stringsToCheck(stringsToCheck.Length - 1))
    End Sub

    Function InsertIntoSortedArray(ByVal strings As String(), ByVal newString As String) As String()
        ' 新增字串到有序字串陣列中，保持字母順序
        Dim index As Integer = 0

        While index < strings.Length AndAlso String.Compare(newString, strings(index), StringComparison.Ordinal) > 0
            index += 1
        End While

        Array.Resize(strings, strings.Length + 1)

        For i As Integer = strings.Length - 1 To index + 1 Step -1
            strings(i) = strings(i - 1)
        Next

        strings(index) = newString

        Return strings
    End Function

    Sub DisplayInRichTextBox(ByVal strings As String())
        ' 顯示文字在 RichTextBox 中，改變新增字串的顏色為紅色
        RichTextBox1.Clear()

        For i As Integer = 0 To strings.Length - 1
            If i > 0 Then
                RichTextBox1.AppendText("|")
            End If

            ' 檢查是否為新增的字串，如果是，則設定紅色
            If strings(i) = TextBox2.Text Then
                RichTextBox1.SelectionColor = Color.Red
            Else
                RichTextBox1.SelectionColor = RichTextBox1.ForeColor
            End If

            RichTextBox1.AppendText(strings(i))
        Next
    End Sub
End Class







'Public Class Form1

'    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
'        ' 從 TextBox 取得原始字串
'        Dim originalString As String = TextBox1.Text

'        ' 新增的字串
'        Dim newString As String = TextBox2.Text

'        ' 將原始字串轉為字串陣列
'        Dim stringsToCheck As String() = originalString.Split("|"c)

'        ' 新增字串到列表中，保持字母順序
'        Dim resultArray As String() = InsertIntoSortedArray(stringsToCheck, newString)

'        ' 將結果輸出到 RichTextBox，不改變顏色
'        DisplayInRichTextBox(resultArray)
'    End Sub

'    Function InsertIntoSortedArray(ByVal strings As String(), ByVal newString As String) As String()
'        ' 新增字串到有序字串陣列中，保持字母順序
'        Dim index As Integer = 0

'        While index < strings.Length AndAlso String.Compare(newString, strings(index), StringComparison.Ordinal) > 0
'            index += 1
'        End While

'        Array.Resize(strings, strings.Length + 1)

'        For i As Integer = strings.Length - 1 To index + 1 Step -1
'            strings(i) = strings(i - 1)
'        Next

'        strings(index) = newString

'        Return strings
'    End Function

'    Sub DisplayInRichTextBox(ByVal strings As String())
'        ' 顯示文字在 RichTextBox 中，改變新增字串的顏色為紅色
'        RichTextBox1.Clear()

'        For i As Integer = 0 To strings.Length - 1
'            If i > 0 Then
'                RichTextBox1.AppendText("|")
'            End If

'            ' 檢查是否為新增的字串，如果是，則設定紅色
'            If strings(i) = TextBox2.Text Then
'                RichTextBox1.SelectionColor = Color.Red
'            Else
'                RichTextBox1.SelectionColor = RichTextBox1.ForeColor
'            End If

'            RichTextBox1.AppendText(strings(i))
'        Next
'    End Sub

'End Class
