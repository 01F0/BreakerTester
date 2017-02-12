# BreakerTester
A simple tool for physically testing breaker events on electrical meters.

# Usage
This repo consists of two parts, one is the WPF UI and the other part is the Lua code which should be uploaded to a NodeMCU unit.
The idea here is to physically control the phase breakers of an electrical meter by using the UI shown below. Then you can validate the events that the meter generates against the ones you generated with this utility.

The UI client sends bytes [0x49 - 0x52] to the NodeMCU unit which flips the PWM servos depending on the byte sent.

![Screenshot] (https://github.com/01F0/BreakerTester/blob/master/Screenshot.png)
