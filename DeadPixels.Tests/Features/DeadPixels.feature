Feature: DeadPixels
	As a customer
	I need to know how many dead pixels groups are in my monitor

Scenario: Finding dead pixel group count
	Given the monitor pixels are <pixels>
	Then the group count should be <expected>
Examples: 
| pixels                                    | expected |
| ['1','0','1'],['0','0','0'],['1','0','1'] | 4        |
| ['1','1','1'],['1','0','0'],['1','0','1'] | 2        |
| ['0','0','0'],['0','0','0'],['0','0','0'] | 0        |
| ['1','1','1'],['1','1','1'],['1','1','1'] | 1        |
| ['1','0','1'],['0','1','0'],['1','0','1'] | 5        |

Scenario: Find dead pixel group on a non existant monitor
	Given there is no monitor
	Then an ArgumentNullException should be thrown

Scenario: Find dead pixel group on a 0 pixel monitor
	Given the pixel count of the monitor is 0
	Then an ArgumentException should be thrown