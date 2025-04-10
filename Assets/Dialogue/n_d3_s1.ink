// Tags Key
// s [name] = speaking [name]
// h [num]  = head [sprite num]
// b [num]  = body [sprite num]
// a [num]  = arms [sprite num]
// p [num]  = hair [sprite num]

“Gooood Morning!!” # s Nessie # a 3 # b 1 # h 1 # p 1

<i>Nessie seems more chipper than the previous evening, maybe she has had better luck with the guests?</i> # s You

“Do you want the good news or the bad news first??” # s Nessie # a 2 # h 6 # a 1 # p 2

<i>Good news first, always the better option.</i> # s You

“A positive one. That’s what I like to see!” # s Nessie # a 1 # p 1 # h 2

“Well… go on and close your eyes. I won’t be a minute!” # h 1

<i>You oblige, covering your face. You wonder what crazy plan she’s come up with this time…</i> # s You

“You can open them now!” # s Nessie # b 2 # a 0 # h 0 # p 0

<i>You uncover your eyes to reveal Nessie in a wetsuit. How did she find equipment this quickly??</i> # s You

“Wow! Mission success, I take it?” 

“Uhhh, kind of.” # s Nessie

<i>Her face remains cheerful, but her voice doesn’t match. She quickly puts her lab coat back on, covering up the diving gear.</i> # s You # b 1 # h 1 # a 1 # p 1

“I got a very angry text this morning from my supervisors…” # s Nessie # h 4 # p 2 # a 2

“It seems like my laptop sent out some sort of distress ping from its accidental resting place at the bottom of your lake.”  # h 6 # p 1

“Needless to say, they were <i>NOT</i> impressed with me.” # h 4 # p 2

“If my research isn’t recovered, my internship may be at risk!!” # a 3 # p 3 # h 5

<i>She sighs, eyes tearing up.</i> # s You # h 4 # p 1

“I worked so hard for this, so it seems such a waste to lose it all for a silly mistake.” # s Nessie # a 1 # p 2

“The hydrated logs need my help!!” # a 3 # h 5 # p 3

*[“You need to be more careful.”] -> careful
*[<i>Express that it isn’t her fault.</i>] -> notyou

=== careful ===

“You think I don’t know that already??!” # s Nessie # minus 1 # h 5 # p 3 # a 1

“I really don’t need two people telling me off today.” # h 4 # p 2 

“I thought you were here to help me…” # a 2 # h 6 # p 1

<i>She looks off into the distance sadly. You don’t know how to explain that you were only trying to encourage her to be mindful for the future.</i> # s You # h 4 # p 2

<i>Great going, you.</i> # a 1

-> stepback

=== notyou ===

“They should be more understanding. Accidents happen!” # s You # plus 1

“I know, right?? Especially since our facility is near water, for water based creatures.” # s Nessie # a 3 # h 1 # p 1

“I would have thought this is a common issue with an easy solution.” # a 1 # h 5 # p 2

“I suppose they are just being harsh to encourage me… Still, I really want this job!”  # h 3 # p 3 

<i>You try your best to reassure her. You will find a way to get this all sorted. Her research isn’t lost just yet!</i> # p 1 # h 5 
-> stepback

=== stepback ===

“Let’s take a step back for a minute and think.” # s You

“Alright, yeah. You’re right. There’s no use stressing out right away.” # s Nessie # a 1 # h 1 # p 2

“That um, wasn’t all my bad news though…”  # a 2 # h 4

<i>You notice she makes a concerted effort to maintain composure.</i> # p 1

“You’ve seen my new wetsuit, but I am still missing some stuff.” # a 1 # h 5

“I still need a diving tank to be able to reach the right water level…” # p 2

“So uhh, I’m going to have to ask you again…” # a 3 # h 1

<i>You had a gut feeling this was coming from a mile away…</i> # s You

“<i>PLEASEEEE</i> can I use your computer??” # s Nessie # a 2 # p 3 # h 1

“It’ll only be for 5 minutes, you could even do it for me!” # a 3 # p 1 # h 2

“I just have to order the remaining equipment, I even got a good website recommendation from Critter!!” # a 1 # h 1 # p 3

<i>Even thinking about the havoc she could cause to the Foggy Lake Systems fills you with great unease…</i> # s You # p 1

*[“Fine, alright.”] -> computerok
*[“I really can’t.”] -> computerdeny

=== computerok ===

<i>You really feel her plight. Besides… your Boss can’t really be watching every single move you make, right?</i> # s You # plus 1 

“I will do this for you, just this once.” 

“Yay!!! Thank you, THANK YOU!!” # s Nessie # a 3 # h 2 # p 3

“But… You are <i>not</i> touching the computer. I will do everything for you.” # s You # p 2 # h 1

“Ok! That seems pretty fair.” # s Nessie # a 2 # p 1

“I’m really really happy you changed your mind, receptionist!!” # h 2 

“I have to go and prepare right away!! Everything is gonna turn out ok, I knew you’d pull through for me!” # a 1 # p 3 # h 1

“Thank youuuuuuuuuuu!!!!!!!!!!!” # a 3 # p 1

<i>Her voice echoes down the hall as she skips away happily. You feel warm inside knowing you were able to solve another person's problems.</i> # s You

 <i>You reassure yourself. Everything will be ok. Nessie will make it through this, and so will you.</i>

-> END

=== computerdeny ===

<i>It feels like a struggle to get the words out, knowing how she will react.</i> # s You # minus 1 # h 6 # a 2

“Oh… I see how it is.” # s Nessie # h 4 # p 2

“It’s ok!! I know you are under a lot of pressure right now too!” # a 1 # h 1 # p 1 

“I can always ask around… again.” # h 3 # p 2 

<i>The air has become overwhelmingly awkward. You felt like you were making so much progress too…</i>  # s You # p 1 # h 5 

“I can maybe put out an inquiry to the other guests?” 

“Sure, yeah. Maybe that could help.” # s Nessie # a 3 # h 1 

“Excuse me, I have to go write up a report… on paper…” # a 1 # h 4 # p 2

<i>She trudges off sadly, and you feel kind of bad. The oppressive feeling of eyes on the back of your head has faded. You sigh in relief.</i> # s You # b 0 # a 0 # h 0 # p 0

-> END
