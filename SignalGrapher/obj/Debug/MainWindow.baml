   M S B A M L   `   `   `  ����H  DSignalGrapher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SignalGrapherSignalGrapher  5   	       SignalGrapher.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SignalGrapher     5   	     � Title$  
MainWindow��5   	   $	��650��6   $	��800��6)   
���   �.��5
      � -   5        $
��Grid��5
      
�������$	��450��6*   $	��800��67   $	��Top=�5      $��Center=�6    � ShowGridLines .  � IsSharedSizeScope . $��4��6m   $��2��6�    � ColumnDefinitions 5      �� 5      $
��.25* �6   �� 5      $
��.25* �6   �� 5      $
��.25* �6   �� 5      $
��.25* �6    � RowDefinitions 5      �� 5      $	��225 �6   �� 5      $	��225 �6   .+�5      �� $��0��6	   $��0��6   $��2��6&   $��6��67   $��Bottom=�5      
���   �$��3��60   	 �� X2 5      ��  �� Path$ ActualWidth� �� RelativeSource �� *Self+�� 5      $��0��6	   $��2��6   $��1��6'   $��2��6;   $
��Left=�5      
���   �$��3��60   	 �� Y2 5      �� $ ActualHeight� �� *Self+�� 5      -   5        $��Controls��5      
�����p�$
��Left=�63   $	��184��6N   $��0,223,0,-182q�6[   $	��Top=�6r   $	��800��6�   	 J� RenderTransformOrigin$	 -0.265,0.16&�6�   $��4��6�   $��1��6�   .+�5      �� $��Waveform��6   
 �� Left$
 88��6   
 �� Top$ 27��6/   $��74��6?   �� 5      -   5        $��
CBWaveform��5      $
 88��6    $ 58��61   $	��120��6A   �� 5      $��	Frequency��6   $	
 262��6   $ 27��61   $	��120��6A   �� 5       -   5        $��TextFreq��5       $��23��6e   $	
 262��6q    �� TextWrapping$
 Wrap=�6�   $ 58��6�   $	��120��6�   ��6   �� *Freq+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5!      $��	Amplitude��6   $	
 437��6   $ 27��61   $	��120��6A   �� 5"      -   5        $��TextAmp��5"      $��23��6a   $	
 437��6m   $
 Wrap=�6   $ 57��6�   $	��120��6�   ��6   �� *A+$ TwoWay=�$ PropertyChanged=�6�   �� 5#      $��Sampling Frequency��6   $	
 612��6(   $ 27��6:   $	��120��6J   �� 5$      -   5        $��TextFs��5$      $��23��6b   $	
 612��6n   $
 Wrap=�6�   $ 57��6�   $	��120��6�   ��6   �� *Fs+$ TwoWay=�$ PropertyChanged=�6�   �� 5%      $��	Harmonics��6   $	
 262��6   $ 97��61   $	��120��6A   �� 5&      -   5        $��TextHar��5&      $��23��6i   $	
 262��6u   $
 Wrap=�6�   $	 123��6�   $	��120��6�   $	 0.475,0.548&�6�   ��6   �� *	Harmonics+$ TwoWay=�$ PropertyChanged=�6�   5'      5(      5)      