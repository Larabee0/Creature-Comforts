// Tags Key
// s [name] = speaking [name]
// h [num]  = head [sprite num]
// b [num]  = body [sprite num]
// a [num]  = arms [sprite num]
// p [num]  = hair [sprite num]


“How’s my favorite receptionist doing???” # s Nessie # b 1 # a 3 # h 1 # p 1

“No need to answer, I can already tell you are having a wonderful morning!” #  h 2

<i>Boy do you wish that were true.</i> # s You

“Did you figure out what to do about the lake yet?” # a 1 # p 2 # h 4

“Oh! Uhhhhh…nope." # s Nessie # a 2 # h 6

"Not yet.” # h 4

<i>She seems shifty, as if she wants to say something but isn’t sure.</i> # s You # p 1

“Say, how do you feel about this job? Is your Boss nice??” # s Nessie # h 1

“Are they a lenient employer?” # h 6

<i>Yeah, this is odd.</i> # s You # a 1

<i>You are very conscious about your answer here, just in case your Boss is somehow miraculously listening in.</i> # h 1

*[<i>Give her the corporate answer.</i>] -> corporate
*[<i>Tell her the truth.</i>] -> bosstruth
*[“Honestly, it doesn't matter to me.”] ->nonchalant

=== corporate ===

“Foggy Lake Motel excels at employee welfare and always strives to make the workplace a habitable environment for all.” # s You # minus 1 # h 1 # p 1

<i>Nessie looks as if she’s trying not to laugh.</i> # p 2

“Did your Boss tell you to say that if anyone asked??” # s Nessie # a 2 #  # p 1 # h 5

<i>You shrug nonchalantly. She doesn’t need to know about his seemingly omnipresent awareness of criticisms.</i> # s You 

-> honesty

=== bosstruth ===

“Job’s fine. As strict as any other workplace.” # s You # plus 0  # h 1

“Hmm… interesting.” # s Nessie # a 2 # h 6 # p 1

<i>It appears as if she’s taking mental notes.</i> # s You

-> honesty

=== nonchalant ===

“You’re just here to get through the day then. I see how it is.” # s Nessie # plus 1 # a 1 # h 1 # p 3

“Pretty much!” # s You # p 1

<i>It feels like unseen eyes are on you as you form your next sentence.</i>

“My Boss can be… a lot. It’s alright though, I don’t mind. Anything for the guests!”

<i>She seems pleased with your self assuredness.</i> # h 2 # a 2

<i>You are always torn between helping someone out and angering your Boss, but the job wants what it wants, and guests ought to leave satisfied.</i>

-> honesty

=== honesty ===

“Alright Nessie, time to be honest. Deep breaths.” # s Nessie # a 2 # h 4 # a 2 # p 2

“I <i>REALLY</i> need to access your computer." # h 5 # a 3 # p 3

"As soon as possible.” # a 2 # h 1 # p 2

<i>Uh oh. Computer access is employees only, no messing about.</i> # s You

<i>You were once docked a week's pay just for playing flappy flatwoods monster on the internet during your break.</i>

*[“I would if I could…”] -> yespc
*[“No way.”] -> nopc

=== yespc ===

<i>You really are sorry you can’t offer her anything else.</i> # s You # plus 1 # a 2 # h 4 # p 2

<i>To let a guest use the Motel Systems would spell disaster.</i>

“I see… It’s ok. I get it.” # s Nessie # a 1 # h 1

“I don’t want to get you in trouble if I can avoid it!!” # h 3 # p 3

<i>You apologise and thank her for the understanding. Guests with her kindness are unusual and sorely missed.</i> # s You # p 1 # h 4

->planfoiled

=== nopc ===

“Pretty pretty please?? I promise I won’t break it, or download any weird programs...” # s Nessie # minus 1 # a 3 # h 4 # p 2

<i>She grins nervously, which only makes you suspicious of her prior track record with borrowing computers.</i> # s You # a 2 # h 1

“I can’t let you do that, I’d get in heaps of trouble.” # a 1 # h 5 

<i>She looks downtrodden, but gets back to muttering things about more plans and workarounds, so you suppose it takes more than that to stop her optimism.</i> # a 2 

-> planfoiled

=== planfoiled ===

“With that plan foiled I guess I’ll just have to leave you alone <i>again</i>.” # s Nessie # a 2 # h 6 # p 1

“I bet I’m a real nuisance with the coming and going and then coming back again.” # a 3 # h 1 

<i>You do your best to reassure her with your customer service expression that it is all a part of the job.</i> # s You # a 1

“There’s no need to be so corporate sometimes, jeez!” # s Nessie # h 5 # p 3

<i>She bounces off to her room, and you are grateful to have some peace and quiet once more.</i> # s You # h 0 # b 0 # a 0 # p 0

-> END