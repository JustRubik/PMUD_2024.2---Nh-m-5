   M S B A M L   `   `   `  ����   
QuanLySVBK"    QuanLySVBK.DanhMucLopHocPhan   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $
��Auto��$
��Auto��.���� ���#F0F0F0  �� CornerRadius$  10�� �� Padding$ 0q�$	��950��$	��480��._��  � ColumnDefinitions �� $��* ��� $	��150 �.+�� $��0��$��15q� � RowDefinitions �� $
��Auto ��� $��* �.+�9� $��0�� 9� 
IsExpanded$
 True��$��13(�$��0,0,0,10q�.���� $��10q�.+���  �� Orientation$ 
Horizontal=�$��0,0,0,10q�.+��� $ 
Horizontal=�$	��400��.+��� $��
Mã lớp:��$	��100��$��Center=�$��13(��� -    ��Name$ TxtMaLop��$	��200��$��Center=��� $ 
Horizontal=�$��20,0,0,0q�.+��� $��Mã học phần:��$	��100��$��Center=�$��13(��� -   $ TxtMaHP��$	��200��$��Center=��� $ 
Horizontal=�$��0,0,0,10q�.+��� $ 
Horizontal=�$	��400��.+��� $��
Kì học:��$	��100��$��Center=�$��13(��� -    ��Name$ CboMaKi��$	��200��$��Center=��� $ 
Horizontal=�$��20,0,0,0q�.+��� $��Mã Viện:��$	��100��$��Center=�$��13(��� -   $ 	CboMaVien��$	��200��$��Center=��� $ 
Horizontal=�.+��� $��Mã GV:��$	��100��$��Center=�$��13(��� -   $ 	TxtMaGVHP��$	��200��$��Center=�&   System.Windows.Controls.DataGrid  -     Name$ dgLopHocPhan��$��1��	   AutoGenerateColumns$	 False��$��0,10,0,0q�
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	Mã lớp��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *MaLop+  $ Mã HP��$ *  �� *MaHP+  $ Tên HP��$
 auto  �� *TenHP+  $ 	Kì học��$ *  �� *MaKi+  $ 
Mã Viện��$
 auto  �� *MaVien+  $ Giảng viên��$ *  �� *MaGVHP+�� $��1�����	#FFF0F0F0���	#FFCCCCCC$��1,0,0,0q�$  	0 10 10 0��._��� $��Center=�$��10q�$��Stretch=�.+��� -    ��Name$ 
BtnTimKiem��$��	TÌM 🔍��$��0,0,0,12q�$
��10,5q����#5DADE2
�������$��SemiBold"��� -   $ 
BtnThemMoi��$��	THÊM ➕��$��0,0,0,12q�$
��10,5q����#2ECC71
�������$��SemiBold"��� -	   $ BtnXoa��$��XÓA ❌��$��0,0,0,12q�$
��10,5q����#E74C3C
�������$��SemiBold"��� -
   $ 
BtnCapNhat��$��CẬP NHẬT 🔄��$��0,0,0,12q�$
��10,5q����#9B59B6
�������$��SemiBold"��� -   $ BtnInDS��$��
IN 🖨️��$
��10,5q����#F39C12
�������$��SemiBold"�