   M S B A M L   `   `   `  ����I  EGameKeyManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:GameKeyManager.ViewModelsGameKeyManager.ViewModels  5      &     GameKeyManager.Views.LibraryView   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      6vm'clr-namespace:GameKeyManager.ViewModels     5        � 	Resources  5         ModernTextBox �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius ��Name �� Triggers P� Property	 P� Value��%i  &	        �� 5   
   " ��6&   .�5	      ��  � �� �#3A3A3A6+   �� 5
       � ��
 �����6+   �� 5       � �� �#5A5A5A6,   �� 5       � ��$ 1q�60   �� 5       � ��$
 10,8q�6(   �� 5       � ��$ 14(�6)   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 4��5   !   ._�5      �� $ PART_ContentHost��6+   #��z��5   )   5       5      P� 5       �@J�	IsFocused$
	 True��6;   . �5   "   ��  � �� �#007ACC6@   5      5      5       5!      5"      .��5$      � 
 � RowDefinitions
 5%   
   �� 5&      $
��Auto �6   �� 5'      $
��Auto �6   �� 5(      $��* �6   .+�5,   
   �� $��0��6   $��0,0,0,20q�6   ._�5-      �� #��[  6   $	��300��5.      $
��Left=�5/      ��50      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�51      �� 54   
   $��1��6   ���#2D2D30 �� Padding$ 15,10q�63   $ 4��6C   $��0,0,0,15q�6T   ._�55      ��  �� Orientation$ 
Horizontal=�6   .+�56      �� $��📊 ��6   
�������$��14(�6:   $��Center=�6H   �� 57      
�������$��14(�59      $��Center=�5:      $��0,0,20,0q�5;      ��57      �� *	GameCount+5;      �� 5<      $��💰 ��6   
�������$��14(�6:   $��Center=�6H   �� 5=      ���#4CAF50$��14(�5?      $��Center=�5@      ��5=      �� *
TotalValue+5@      5A      5B      &   System.Windows.Controls.DataGrid  5E   
   -   5          Name$ GameDataGrid��5E      $��2��5G      ���#2D2D30
����������#3E3E42$��1q�5K         GridLinesVisibility$ 
Horizontal=�5L         HorizontalGridLinesBrush �#3E3E42   AutoGenerateColumns$ False��5N         CanUserAddRows$ False��5O         CanUserDeleteRows$ False��5P         SelectionMode$ Single=�5Q         AlternatingRowBackground �#252526   RowBackground �#2D2D30   HeadersVisibility$ Column=�5T      ��5F      �� *Games+   ColumnHeaderStyle 5V      �� 5W      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5X      ��  � �� �#3A3A3A63   �� 5Y       � ��
 �����63   �� 5Z       � �� �#3E3E4264   �� 5[       � ��$ 0,0,1,1q�68   �� 5\       � ��$
 12,8q�60   �� 5]       � ��$ SemiBold"�63   5^         	CellStyle 5a      �� 5b      *  $System.Windows.Controls.DataGridCell"  6   .�5c      ��  � ��$ 0q�68   �� 5d       � ��$
 12,8q�60   �� 5e       � ��
 ���� 63   �� 5f       � ��
 �����63   5g         Columns 5j      0  *System.Windows.Controls.DataGridTextColumn  5k      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Game Title��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6S      MinWidth$	 200Q�6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Title+6]     5l      $ Platform��6%   $	 100 6T    67   �� *
Platform+6T   4  .System.Windows.Controls.DataGridTemplateColumn  5o      $ Actions��6)   $	 120 6:      CellTemplate 5p      �� 5q      .R�5r      �� $ 
Horizontal=�6)   .+�5s   "   �� $��✏️��6)   
������ $��0q�5w   )   ���#4CAF50  � Cursor$
  Hand��5y   )   ! � ToolTip$
! Edit��5z   )   $��0,0,5,0q�5{   )   ��5t   )   �� *DataContext.EditCommand+" �� RelativeSource" �� # �� AncestorType# UserControl��5u   )   �� 5{   )   �� 5|   "   $��🗑️��6)   
������ $��0q�5�   )   ���#F44336$
  Hand��5�   )   $! Delete��5�   )   ��5}   )   �� *DataContext.DeleteCommand+" �� # UserControl��5~   )   �� 5�   )   5�      5�      5�      5�      5�      5�      