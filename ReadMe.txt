UnityVer 6000.1.12f1
Itch:
On this project i started to consider project architecture and work distribution among members. 
Idea behind it was to create system designer / non programing personnel (user) could use to develop game  / do changes.
 During gameplay enemies spawn in waves, after clearing the wave player gets 3 random upgrades - he can upgrade his health, damage, movement speed, attack speed).
What can be done / managed by scriptable objects: 

Enemy - user can create Scriptable object, set its behavior (logic of different behaviors are scriptable objects), 
set properties (damage, health range, reward score, movement and attack speed). 
For enemies that spawn smaller ones upon death user can select what kind and amount of spawned enemies. 
For ranged Enemies user can choose ranged attack type (Action)/ projectile (singleshot, multiple proejctiles shot and specify their dispersment). 
These enemies can be then put into Wave Configurations that can be used in scene. User can test  one or multiple waves, game wil cycle through them. 
ActionSOs are used for players weapons as  well - the idea was to create versatile system.
Export of confluence articles ive made:
https://drive.google.com/file/d/1t5HR4K7Md7qBX_Kb6Zv9Lc1ChEnNEBIc/view
