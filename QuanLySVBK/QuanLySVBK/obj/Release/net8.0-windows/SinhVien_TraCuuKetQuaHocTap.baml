   M S B A M L   `   `   `  ����   
QuanLySVBK,    &QuanLySVBK.SinhVien_TraCuuKetQuaHocTap   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � 	Resources     PrimaryButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding �� Triggers	 P� Property
 P� Value �� 
TargetName �� ScaleX �� ScaleY  SearchButtonStyle �� BasedOn  StandardTextBoxStyle  HeaderTextBlockStyle  SectionHeaderStyle��%�  &	        &	 �    7   &	 =    &	 �    &	 4    �� " ��.���  � �� �#2196F3��  � ��
 �������  � �� �#1976D2��  � ��$ 1q���  �@�Cursor$
 Hand����  � ��$ SemiBold"���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$ 5��# z��._��� $��Center=�$��Center=� P� 	 � ��$

 True��. ��� $ border�� � �� �#1976D2�� $ border�� � z� �� $
 0.97Q�$
 0.97Q��� $ border�� �@J�RenderTransformOrigin$ 0.5,0.5&��� " ��8   .���  � ��$	 100����  � ��$ 32����  � ��$ 10,0,0,0q��� " ��.���  � ��$ 20����  � ��$ Center=���  � ��$	 2,0q���  � ��$ 0,0,5,5q���  � ��$ 12(��� " ��.���  � ��$
 Bold"���  � ��$ Center=���  � ��$	 120����  � ��$ 0,0,10,0q��� " ��.���  � ��$ 16(���  � ��$
 Bold"���  � �� �#1976D2��  � ��$ 0,0,0,10q�.���� ���#F0F0F0$ 8��$ 15q�._��� .+��� ���#F0F0F0$ 10q�$ 5��$��	0,10,0,10q�._��  � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto ��� $��* � � RowDefinitions �� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��	Mã kỳ:��#��[ �� $��0��$��1��#��[ �� $��1��$��0��$��Mã học phần:��#��[ �� $��1��$��1��#��[ �� $��0��$��3��$��2��#��[ $��🔍 Tra cứu���� ���#F0F0F0$ 5��$ 10q�._�&   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��   HeadersVisibility$ Column=�   CanUserAddRows$ False��   CanUserDeleteRows$ False��   
IsReadOnly$
 True��$��0q�$	��250��$��1q�$
��Auto=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Mã học phần��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *MaHP+  $ Tên học phần��$ 2*  �� *TenHP+  $ Số tín chỉ��$
 Auto  �� *
SoTinChi+  $ Điểm hệ 10��$
 Auto  �� *
DiemHe10+  $ Điểm chữ��$
 Auto  �� *	DiemChu+  $ Điểm hệ 4��$
 Auto  �� *	DiemHe4+  $ Kết quả��$
 Auto  �� *KetQua+