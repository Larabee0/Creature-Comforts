// Tags Key
// s [name] = speaking [name]
// h [num]  = head [sprite num]
// b [num]  = body [sprite num]
// a [num]  = arms [sprite num]
// e        = end tag

“Good Morning, am I the first one here?” # s Mothman #h 2 # b 2 # a 2
<i>You consider the early hour, thinking back to the start of your shift.</i> # s You

*[“I’ve seen other guests come through today.”] -> option1
*[“I thought moths were nocturnal…”] -> option2
*[“Yes, you are!”] -> option3 

=== option1 ===

“That’s just <i>great</i>. This could be a big problem.” # s Mothman # h 10 
“Why does trouble always seem to follow my vacation leave…” # h 5
-> lastnight

=== option2 ===

“Excuse me? You’re far too nosy for a receptionist.” # s Mothman # h 10
“There are better things to do than pry into guests' personal matters.” # h 1 # b 1 # a 3
“In regards to your question, I get up when I please. Happy now?”
<i> You crack a small smile, which he doesn’t seem to find amusing.</i> # s You # h 2
-> lastnight

=== option3 ===

“Splendid. There may still be time yet to fix this.” # s Mothman # h 3
“My early tendencies have always served me well.” 
-> lastnight

=== lastnight ===

“Enough with the small talk, let's address the matter at hand.” # s Mothman # h 1 # b 2 # a 2
“Although, it’s not like you seemed to be doing much before I arrived.” # h 9
“I just have one little inquiry. Then I’ll be on my way.” # h 2

<i>You feel like he seems hesitant to ask you whatever is on his mind.</i> # s You

“Has…anyone else checked in since last night?” # s Mothman # b 1 # a 1 # h 11 
“They would be wearing a tie of some sort, if that helps at all.”

<i>You try to recall the events of last night. Is it wise to be spilling company info to strangers?</i> # s You

*[“I can’t tell you that. Receptionist's honor!” ] -> lastnight1
*[“Nope, no one else.”] -> lastnight2

=== lastnight1 ===

 “Seriously? Is that what you call customer service in this part of the woods?” # s Mothman # h 11 # b 2 # a 2
 “I can’t believe I have to figure this out on my own…” # h 10
 -> managerlocation

=== lastnight2 ===

“You were the last guest to check in.” # s You 
 
<i>Well.. apart from that frazzled reptile woman. That doesn’t seem to be who he’s looking for though.</i>
-> managerlocation


=== managerlocation ===

“Rats! I must have lost them.” # s Mothman # h 7 # b 1 # a 3

<i>They look around the lobby with a concerned expression.</i> # s You # h 10

“I knew I shouldn’t have flown in. They can never keep up with me…” # s Mothman 
“Ok. <i>Calm.</i> A welcome break, peace and quiet. This will be good for you.” # h 11

<i>He seems anything but calm.</i> # s You

*[“Is there anything I can help with?” ] ->managerloc1
*[ <i>Leave him to his muttering.</i>] -> managerloc2

=== managerloc1 ===

“Not that <i>you</i> can help with, no. You’ve done enough already.” # s Mothman # h 1 # b 2 # a 2
“I need a cup of coffee. Where is the machine?” # h 10

<i>You point him in the direction of the coffee station. By the time your hand is raised, he’s already halfway down the corridor…</i> # s You # b 0 # h 0 # a 0
-> sc1end

=== managerloc2 ===

“Damn manager. My publishers won’t like a word of this.” # s Mothman # h 10 # b 2 # a 2
“I need to go back to my room and make some calls.” # h 2

<i>He doesn’t appear to be paying attention to you any more.</i> # s You
-> sc1end

=== sc1end ===

<i>Well…that was pretty peculiar. Maybe he will return later?</i> # s You # h 0 # b 0 # a 0
-> END
