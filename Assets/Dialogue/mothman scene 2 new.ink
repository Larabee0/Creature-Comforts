// Tags Key
// s [name] = speaking [name]
// h [num]  = head [sprite num]
// b [num]  = body [sprite num]
// a [num]  = arms [sprite num]

"Hello again, don't suppose you've heard any word?" # s Mothman # b 1 # a 3 # h 2

<i>You decline to mention the fact you were never very sure who to look for in the first place.</i> # s You

"No. Afraid not."

“Wonderful.” # s Mothman # h 1
“I’m expecting a call, please forward it to my room.” # b 2 # a 2 # h 2

“I’m going to need to take down a name please.” # s You

“Fine. It should be an associate of P. Pleasant Publishing.” # s Mothman
“They will be wanting to hear about this situation.” # h 1

<i>He pauses to sigh. Doesn’t seem like this vacation is going very smoothly.</i> # s You

“Oh, and if anyone phones under the name Aubrey, please tell them I am very disappointed in them right now.” # s Mothman # h 4
“Might be worth breaking the news yourself honestly, instead of myself." # b 1 # a 3
“They are most definitely fired.” # h 6

<i>You can’t deny being intrigued by this turn of events.</i> # s You

*[“Is Aubrey your manager?”] -> manager1
*[“I’ll let you know if anyone calls!”] -> manager2

=== manager1 ===
“<i>Was</i> my manager, is a more polite way to put it I suppose.” # s Mothman # h 1 # b 2 # a 2
“Whilst I do hope they haven’t befallen any harm, I must say that it is rather fortunate they didn’t make it here with me.”
“We often do not get on. Opposing views and such. Also they were very loud.” # h 5
“This incident will not do wonders to improve my managerial relations.” # h 1
“<i>Especially</i> if Aubrey happens to find their way here after all…” # h 2
-> job

=== manager2 ===
“Thank you. I wouldn't suspect it would be before tomorrow morning, but just in case.” # s Mothman # h 2
-> job

=== job ===
“It’s really important I deal with this as soon as possible.” # s Mothman # b 2 # a 2
“It could put some strain on my career whilst I am on this little trip.” # h 5

“What do you do?” # s You

“Was it not obvious from my questioning? I’m an author, but I prefer the term novelist.” # s Mothman # h 9 # b 1 # a 1

<i>You can’t help but laugh at his hubris.</i> # s You

*[“Come to think of it, your name does ring a bell.”] -> known1
*[“Never heard of you.”] -> known2

=== known1 ===
“I rather think it should! M. Mothman is a household staple.” # s Mothman # h 10
“If you read historical fiction, that is…” # h 3
“I’ve written such classics as <i>‘The Dawning of the Lamp’</i> and <i>‘Beyond the Forest Trees Part 2 featuring new Addendums."</i> # h 9

<i>You decide to let him keep spouting book titles at you. None of them instill any sort of recognition whatsoever.</i> # s You
-> sc2end

=== known2 ===
<i> He stares at you in mock offence. Silent. This is awkward… </i> # s Mothman # h 7
“Never…heard…of…me??”
“You must be lying. I can’t believe it! Either that, or you have no taste.” # h 10
“It seems I’ve come to expect that from this reception.” # h 11
 “I’m a multi award winning bestseller. Look me up.” # h 8
 -> sc2end
=== sc2end ===
“Anyway, enough about my infinitely successful career. I have a draft to review in my room that suddenly seems infinitely more interesting than this conversation. Adieu.” # s Mothman # h 2
<i>Well, he sure is a conversationalist. Make sure to keep an eye out for any phone calls. </i> # s You # b 0 # a 0 # h 0
-> END