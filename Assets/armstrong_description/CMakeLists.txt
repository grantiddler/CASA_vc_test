cmake_minimum_required(VERSION 3.0.2)
project(armstrong_description)

find_package(catkin REQUIRED COMPONENTS roslaunch)

catkin_package()

roslaunch_add_file_check(launch/description.launch)
roslaunch_add_file_check(launch/rviz_urdf.launch)

install(DIRECTORY meshes launch urdf rviz
  DESTINATION ${CATKIN_PACKAGE_SHARE_DESTINATION}
)
