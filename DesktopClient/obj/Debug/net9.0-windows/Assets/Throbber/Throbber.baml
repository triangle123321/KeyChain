   M S B A M L   `   `   `  ����  GameKeyManager-    'GameKeyManager.Assets.Throbber.Throbber   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      $	��120��5      $��30��6     � 	Resources  5         PulseStoryboard g� RepeatBehavior �� 
TargetName �� TargetProperty W� From	 W� To g� Duration g� AutoReverse g� 	BeginTime��%U  &	        �� 5   
   $ Forever��6-   .��5      W� $
 Dot1��6   $ Opacity�5       0.35	       16   $ 0:0:0.6D�6$   $
 True��5
      $ Forever��6%   	 0:0:05      W� 5      $
 Dot2��6   $ Opacity�5       0.35       16   $ 0:0:0.6D�6$   $
 True��5      $ Forever��6%    0:0:0.25      W� 5      $
 Dot3��6   $ Opacity�5       0.35       16   $ 0:0:0.6D�6$   $
 True��5      $ Forever��6%    0:0:0.45      W� 5      $
 Dot4��6   $ Opacity�5       0.35       16   $ 0:0:0.6D�6$   $
 True��5      $ Forever��6%    0:0:0.65      W� 5      $
 Dot5��6   $ Opacity�5       0.35       16   $ 0:0:0.6D�6$   $
 True��5      $ Forever��6%    0:0:0.85      5       5!      	 � Triggers	 5#      :� 5$   
   
 :� RoutedEvent$
 Loaded��6   .[�5%      �� #��[  6   5&      .��5)      ��  �� Orientation$ 
Horizontal=�6   $��Center=�6*   $��Center=�6G   .+�5*   
   A� -   5         A�Name$
 Dot1��5*      $��15��6    $��15��6+   ���#2196F3$��3q�6F    J� Opacity$	 0.3Q�6Q   A� 5+   
   -   5        $
 Dot2��5+      $��15��6    $��15��6+   ���#2196F3$��3q�6F   $	 0.3Q�6Q   A� 5,   
   -   5        $
 Dot3��5,      $��15��6    $��15��6+   ���#2196F3$��3q�6F   $	 0.3Q�6Q   A� 5-   
   -   5        $
 Dot4��5-      $��15��6    $��15��6+   ���#2196F3$��3q�6F   $	 0.3Q�6Q   A� 5.   
   -   5        $
 Dot5��5.      $��15��6    $��15��6+   ���#2196F3$��3q�6F   $	 0.3Q�6Q   5/      50      