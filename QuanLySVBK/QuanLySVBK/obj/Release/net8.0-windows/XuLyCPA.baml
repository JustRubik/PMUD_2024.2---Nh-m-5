   M S B A M L   `   `   `  ���� E  AQuanLySVBK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:QuanLySVBK
QuanLySVBK      QuanLySVBK.XuLyCPA   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:QuanLySVBK     $
��Auto��$
��Auto��.���� ���#F0F0F0  �� CornerRadius$  10�� �� Padding$ 0q�$	��950��$	��480��._��  � ColumnDefinitions �� $��* ��� $
��Auto �.+�� $��0��$��10q� � RowDefinitions �� $
��Auto ��� $��* �.+�9�  9� 
IsExpanded$
 True��$��13(�$��0��.���� .+���  �� Orientation$ 
Horizontal=�$��0,0,0,10q�.+��� $��MSSV:��$	��120��$��Center=�$��13(��� -    ��Name$ TxtMaSinhVien��$	��200���� $ 
Horizontal=�$��0,0,0,10q�.+��� $��
Kì học:��$	��120��$��Center=�$��13(��� -    ��Name$ CboKiHoc��$	��200���� -    ��Name$ ChkCPA��$ ��*CPA tính đến kì này��$��10,0,0,0q�$��Center=�
���  ��&   System.Windows.Controls.DataGrid  -   	  Name$	 dgKetQua��$��1��
   AutoGenerateColumns$
 False��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Mã sinh viên��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *MaSV+  $ Mã môn học��$ *  �� *
MaMonHoc+  $ 	Mã lớp��$
 auto  �� *MaLop+  $ Mã kì��$ *  �� *MaKi+  $ Số tín chỉ��$
 Auto  �� *
SoTinChi+  $ Điểm��$ *  �� *Diem+�� $��1��$	��150�����	#FFF0F0F0���	#FFCCCCCC$��1,0,0,0q�$  10��._��� $��Center=�$��10q�$��Stretch=�.+��� -    ��Name$ BtnXuLy��$��0,0,0,15q����#2E86C1
�������$
��10,5q�$��Stretch=�.���� $ 
Horizontal=�$��Center=�.+��� $��⚙️��$��14(�$��0,0,5,0q��� $��XỬ LÝ��$��SemiBold"��� -   $ BtnInDanhSach��$
��10,5q�$��Stretch=�.���� $ 
Horizontal=�$��Center=�.+��� $��🖨️��$��14(�$��0,0,5,0q��� $��IN DANH SÁCH��$��SemiBold"�