function flip(Servo)
	pwm.setup(Servo.pin, 50, 71)
	if Servo.on then
		print("Flipping down..")
		pwm.setduty(Servo.pin, 27);
		pwm.start(Servo.pin);
		tmr.delay(500000)
		pwm.stop(Servo.pin)
	else
		print("Flipping up..")
		pwm.setduty(Servo.pin, 123);
		pwm.start(Servo.pin);
		tmr.delay(500000);
		pwm.stop(Servo.pin)
	end
	
	return { pin = Servo.pin, on = not Servo.on }
end
	
servo1 =  { pin = 1, on = true }
	
servo2 =  { pin = 2, on = true }

servo3 =  { pin = 3, on = true }

srv=net.createServer(net.TCP)
srv:listen(80,function(conn)
	conn:on("receive",function(conn,payload)
		if string.len(payload) ~= 1 then
			print("Incorrect length, length must be 1.")
			print(string.len(payload))
		else
			id = payload:sub(0,1)
			print(id)
			if id == "1" then
				servo1 = flip(servo1)
			elseif id == "2" then
				servo2 = flip(servo2)
			elseif id == "3" then
				servo3 = flip(servo3)
			else 
				print("unknown id")		
			end
			conn:close()
		end
	end)
end)