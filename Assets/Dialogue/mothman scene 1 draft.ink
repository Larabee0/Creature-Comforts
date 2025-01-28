// Tags Key
// s [name] = speaking [name]
// h [num]  = head [sprite num]
// b [num]  = body [sprite num]
// a [num]  = arms [sprite num]
// e        = end tag

“Good Morning, am I the first one here?” # s Mothman 
You consider the early hour, thinking back to the start of your shift. # s You # h 4 # a 1 # b 1

*[“I’ve seen other guests come through today.”] -> option1
*[“I thought moths were nocturnal…”] -> option2
*[“Yes, you are!”] -> option3 

=== option1 ===

“That’s just great. This could be a big problem.” # s Mothman 
“Why does trouble always seem to follow my vacation leave…” 
-> lastnight

=== option2 ===

“Excuse me? You’re far too nosy for a receptionist.” # s Mothman 
“There are better things to do than pry into guests' personal matters.”
“In regards to your question, I get up when I please. Happy now?”
You crack a small smile, which he doesn’t seem to find amusing. # s You
-> lastnight


=== option3 ===

“Splendid. There may still be time yet to fix this.” # s Mothman 
“My early tendencies have always served me well.” 
-> lastnight

=== lastnight ===

“Enough with the small talk, let's address the matter at hand.” # s Mothman 
“Although, it’s not like you seemed to be doing much before I arrived.”
“I just have one little inquiry. Then I’ll be on my way.”

You feel like he seems hesitant to ask you whatever is on his mind. # s You

“Has…anyone else checked in since last night?” # s Mothman 
“They would be wearing a tie of some sort, if that helps at all.”

You try to recall the events of last night. Is it wise to be spilling company info to strangers? # s You

*[“I can’t tell you that. Receptionist's honor!” ] -> lastnight1
*[“Nope, no one else.”] -> lastnight2

=== lastnight1 ===

 “Seriously? Is that what you call customer service in this part of the woods?” # s Mothman 
 “I can’t believe I have to figure this out on my own…” 
 -> managerlocation

=== lastnight2 ===

“You were the last guest to check in.” # s Mothman 
 
Well.. apart from that frazzled reptile woman. That doesn’t seem to be who he’s looking for though. # s You
-> managerlocation


=== managerlocation ===

“Rats! I must have lost them.” # s Mothman 

They look around the lobby with a concerned expression. # s You

“I knew I shouldn’t have flown in. They can never keep up with me…” # s Mothman 
“Ok. Calm. A welcome break, peace and quiet. This will be good for you.”

He seems anything but calm. # s You
*[“Is there anything I can help with?” ] ->managerloc1
*[ Leave him to his muttering.] -> managerloc2

=== managerloc1 ===

“Not that you can help with, no. You’ve done enough already.” # s Mothman 
“I need a cup of coffee. Where is the machine?”

You point him in the direction of the coffee station. By the time your hand is raised, he’s already halfway down the corridor… # s You
-> sc1end

=== managerloc2 ===

“Damn manager. My publishers won’t like a word of this.” # s Mothman 
“I need to go back to my room and make some calls.”

He doesn’t appear to be paying attention to you any more. # s You
-> sc1end

=== sc1end ===

Well…that was pretty peculiar. Maybe he will return later? -> END
