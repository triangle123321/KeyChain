   M S B A M L   `   `   `  ����I  EGameKeyManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:GameKeyManager.ViewModelsGameKeyManager.ViewModels  5      O,clr-namespace:GameKeyManager.Assets.ThrobberGameKeyManager.Assets.Throbber  5      $    GameKeyManager.Views.LoginView   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >
viewmodels'clr-namespace:GameKeyManager.ViewModels     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Athrobber,clr-namespace:GameKeyManager.Assets.Throbber     5        � 	Resources  5
         	BoolToVis  ModernButton �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding �� Triggers P� Property	 P� Value  ModernTextBox
 ��Name  ModernPasswordBox��%�  &	        &	      &	 �    &	 C    �� 5   
   6'   �� 5   
   " ��6%   .�5      ��  � �� �#3A3A3A6+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$
 15,8q�6(   �� 5       � ��$	 0,5q�6'   �� 5       � ��$ 14(�6)   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 4��5      # z��5      ._�5      �� $��Center=�6/   $��Center=�5   %   5       5      P� 5        �@J�IsMouseOver$
	 True��6=   . �5!   "   ��  � �� �#4A4A4A6?   5"      P� 5#       � ��$
	 True��6;   . �5$   "   ��  � �� �#2A2A2A6?   5%      5'      5)      5*      �� 5-   
   " ��6&   .�5.      ��  � �� �#3A3A3A6+   �� 5/       � ��
 �����6+   �� 50       � �� �#5A5A5A6,   �� 51       � ��$ 1q�60   �� 52       � ��$
 10,8q�6(   �� 53       � ��$ 14(�6)   �� 54       � �� 55      �� 56      " ��6&   .R�57      �� #��z��6!   #��z��58      #��z��59      $ 4��5:      ._�5;      �� $
 PART_ContentHost��6+   #��z��5<   !   5=       5>      P� 5?       �@J�	IsFocused$
	 True��6;   . �5@   "   ��  � �� �#007ACC6@   5A      5C      5E      5F      �� 5I   
   " G�6*   .�5J      ��  � �� �#3A3A3A6+   �� 5K       � ��
 �����6+   �� 5L       � �� �#5A5A5A6,   �� 5M       � ��$ 1q�60   �� 5N       � ��$
 10,8q�6(   �� 5O       � ��$ 14(�6)   �� 5P       � �� 5Q      �� 5R      " G�6&   .R�5S      �� #��z��6!   #��z��5T      #��z��5U      $ 4��5V      ._�5W      �� $
 PART_ContentHost��6+   #��z��5X      5Y       5Z      P� 5[       �@J�	IsFocused$
	 True��6;   . �5\   "   ��  � �� �#007ACC6@   5]      5_      5a      5b      5c      .��5e      �� $	��500��6   $
��Left=�6   .+�5f      �� $��Login��6   
�������$��24(�5h      $
��Bold"�5i      $��0,0,0,20q�5j      �� 5k      $��
Username *��6   ���#CCCCCC$��0,0,0,5q�67   �� 5l      -   5        #��[ 5l      $��0,0,0,15q�5m      $	��300��5n      ��5o      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5p      �� 5s      $��
Password *��6   ���#CCCCCC$��0,0,0,5q�6C   G� 5t      -   5         G�Name$ TxtPassword��5t      #��[ 5u      $��0,0,0,15q�5v      5w      �� 5z       �� Orientation$ 
Horizontal=�6   .+�5{      �� -   5         ��Name$ BtnLogin��5{      $��Log in��5|      #��[ 5}      ���#4CAF50$��0,0,10,0q�5      ��5�      �� *LoginCommand+�� 5�      -   5        $ BtnRegister��5�      $��Register��5�      #��[ 5�      ���#FF9800$��0,0,10,0q�5�      ��5�      �� *RegisterCommand+-   'GameKeyManager.Assets.Throbber.Throbber  5�      y�6(   �� *IsBusy+  BoolToVisibilityConverter �� 	Converter# [ 5�      5�   	   5�      