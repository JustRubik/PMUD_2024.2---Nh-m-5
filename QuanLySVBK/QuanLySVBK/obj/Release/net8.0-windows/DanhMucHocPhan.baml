   M S B A M L   `   `   `  ����   
QuanLySVBK    QuanLySVBK.DanhMucHocPhan   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $
��Auto��$
��Auto��.���� ���#F0F0F0  �� CornerRadius$  10�� �� Padding$ 0q�$	��950��$	��480��._��  � ColumnDefinitions �� $��* ��� $	��150 �.+�� $��0��$��15q� � RowDefinitions �� $
��Auto ��� $��* �.+�9� $��0�� 9� 
IsExpanded$
 True��$��13(�$��0,0,0,10q�.���� $��10q�.+���  �� Orientation$ 
Horizontal=�$��0,0,0,10q�.+��� $��Tên học phần:��$	��120��$��Center=�$��13(��� -    ��Name$ TxtTenHP��$	��400��$��Center=��� $ 
Horizontal=�$��0,0,0,10q�.+��� $ 
Horizontal=�$	��400��.+��� $��Mã học phần:��$	��120��$��Center=�$��13(��� -   $ TxtMaHP��$	��200��$��Center=��� $ 
Horizontal=�.+��� $ 
Horizontal=�$	��400��.+��� $��Mã Viện:��$	��120��$��Center=�$��13(��� -    ��Name$ 	CboMaVien��$	��200��$��Center=��� $ 
Horizontal=�$��20,0,0,0q�.+��� $��Số tín chỉ:��$	��100��$��Center=�$��13(��� -   $ TxtSoTinChi��$	��100��$��Center=�&   System.Windows.Controls.DataGrid  -     Name$ 	dgHocPhan��$��1��	   AutoGenerateColumns$	 False��$��0,10,0,0q�
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Mã HP��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *MaHP+  $ Tên HP��$ *  �� *TenHP+  $ 
Mã Viện��$	 100  �� *MaVien+  $ Số TC��$ 80  �� *
SoTinChi+�� $��1�����	#FFF0F0F0���	#FFCCCCCC$��1,0,0,0q�$  	0 10 10 0��._��� $��Center=�$��10q�$��Stretch=�.+��� -    ��Name$ 
BtnTimKiem��$��	TÌM 🔍��$��0,0,0,12q�$
��10,5q����#5DADE2
�������$��SemiBold"��� -   $ 
BtnThemMoi��$��	THÊM ➕��$��0,0,0,12q�$
��10,5q����#2ECC71
�������$��SemiBold"��� -   $ BtnXoa��$��XÓA ❌��$��0,0,0,12q�$
��10,5q����#E74C3C
�������$��SemiBold"��� -	   $ 
BtnCapNhat��$��CẬP NHẬT 🔄��$��0,0,0,12q�$
��10,5q����#9B59B6
�������$��SemiBold"��� -
   $ BtnInDS��$��
IN 🖨️��$
��10,5q����#F39C12
�������$��SemiBold"�