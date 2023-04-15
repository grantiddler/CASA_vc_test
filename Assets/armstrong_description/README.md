To do a simple launch of RViz with armstrong:
roslaunch armstrong_description rviz_urdf.launch

To convert from urdf.xacro to urdf:
rosrun xacro xacro -o armstrong.urdf armstrong.urdf.xacro

Required packages:
tf2
joint-state-publisher
robot-state-publisher


Angular velocity of wheels:

RPM @ 12V = ~95 RPM -> 9.948 rad/s 
Wheel radius: 0.027844 m

Seperation of one wheel from center of robot: 0.194209
Seperation between wheels: 0.388418

Linear velocity:
w = v/r
9.948 = v / 0.027844
v = 0.27 m/s
