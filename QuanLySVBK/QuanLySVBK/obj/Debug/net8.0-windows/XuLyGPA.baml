   M S B A M L   `   `   `  ����  
QuanLySVBK    QuanLySVBK.XuLyGPA   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      $
��Auto��5      $
��Auto��6   .��5      �� ���#F0F0F0  �� CornerRadius$  10��6"    �� Padding$ 0q�64   $	��950��6@   $	��480��6L   ._�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5	      $
��Auto �6#   .+�5      � $��0��6   $��10q�6#    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      9�  9� 
IsExpanded$
 True��6   $��13(�6-   $��0��6;   .��5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��0,0,0,10q�6>   .+�5      �� $��MSSV:��6(   $	��120��65   $��Center=�6A   $��13(�6\   �� 5      -   5         ��Name$ TxtMaSinhVien��5   &   $	��200��6=   5      �� 5      $ 
Horizontal=�6%   $��0,0,0,10q�6>   .+�5      �� $��
Kì học:��6(   $	��120��67   $��Center=�6C   $��13(�6^   �� 5      -   5         ��Name$ CboKiHoc��5   '   $	��200��69   5       5!      5"      &   System.Windows.Controls.DataGrid  5%      -   5          Name$ dgKetQua��5%   (   $��1��6   	   AutoGenerateColumns$	 False��6:   
   Columns
 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã môn học��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6^   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *
MaMonHoc+6^     5(      $ 	Mã lớp��6-   $	 120 6W    6=   �� *MaLop+6W     5)      $ Tên môn học��6-   $ * 6`    6B   �� *	TenMonHoc+6`     5*      $ Số tín chỉ��6-   $ 80 6^    6A   �� *
SoTinChi+6^     5+      $ Điểm��6-   $ 80 6T    6;   �� *Diem+6T   5-      5.      �� 51      $��1��6   $	��150��6%   ���	#FFF0F0F0���	#FFCCCCCC$��1,0,0,0q�6`   $  10��6z   ._�52      �� $��Center=�6   $��10q�68   $��Stretch=�6D   .+�54      �� -   5         ��Name$ BtnXuLy��54      $��0,0,0,15q�6.   ���#2E86C1
�������$
��10,5q�6h   $��Stretch=�6w   .��55      �� $ 
Horizontal=�6%   $��Center=�6>   .+�56      �� $��⚙️��6(   $��14(�62   $��0,0,5,0q�6@   �� 57      $��XỬ LÝ��6(   $��SemiBold"�65   58      59      �� 5<      -   5        $ BtnInDanhSach��5<      $
��10,5q�64   $��Stretch=�6C   .��5=      �� $ 
Horizontal=�6%   $��Center=�6>   .+�5>      �� $��🖨️��6(   $��14(�63   $��0,0,5,0q�6A   �� 5?      $��IN DANH SÁCH��6(   $��SemiBold"�6<   5@      5A      5B      5C      5D      5E      5F      