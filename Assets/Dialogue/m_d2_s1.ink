// Tags Key
// s [name] = speaking [name]
// h [num]  = head [sprite num]
// b [num]  = body [sprite num]
// a [num]  = arms [sprite num]


<i>So much for another uneventful morning. You go to answer the aggressively ringing phone, praying it isn’t your Boss.</i> # s You

“Hello? Is this Foggy Lake Motel?” # s Publisher

<i>You don’t seem to recognise the voice on the other end, and guests rarely seem to book over the phone these days.</i> # s You

<i>This must be Mothman’s publishers.</i>

“Yes, you’re speaking to the receptionist. What can I help you with today?”

<i>Feigning ignorance is the best way to gather information.</i>

“Excellent. This is Mr K. Kappa from marketing and public relations.” # s Publisher

“The company wishes to speak to our client, one Mr M. Mothman, who appears to have checked into your establishment a few nights ago.”

<i>A sense of justice overtakes you. You want to solve this problem for your guest before he can even get to it. They did look pretty stressed.</i> # s You

<i>Besides, the Motel system is so ancient the ability to forward calls to rooms takes the better half of an entire morning to set up.</i>

<i>Looks like this conversation is up to you now.</i>

“He is staying here, however I am unable to forward your call right now.”

“I can pass a message on to him?”

“Not ideal, but I can work with this. Please have a pen ready.” # s Publisher

<i>You wait with bated breath, pulling up a notepad.</i> # s You

“First to discuss, I have been dutifully instructed to inform Mr Mothman that unsanctioned travel to a location off of his schedule, during a work period, is and <i>always</i> has been, impermissible.” # s Publisher
 
“He is usually very amenable and polite in temperament, although the past couple of months have been… rough, especially for poor Aubrey.”

<i>Mothman wasn’t lying about his publishers being harsh. Given his bout of nerves, you aren’t surprised he decided to take a little breather.</i> # s You

“We have heard of Aubrey’s disappearance, which is not ideal. They had a very important briefcase full of our latest business triumph-<i>‘Conquer the Conquered: A Roman Tale of Woe’</i>.” # s Publisher

“You see, the public were tired of knights with big swords, and dramatic outbreaks of influenza.”
 
“This title is sure to be our greatest bestseller yet, and all written by our very own established household name.”

“Forgive me for the dramatics, but I’m sure you understand where we are coming from. It is vitally important to us that this tour gets back on track as soon as possible.”
 
“Of course, we will compensate your establishment with any costs incurred from our dear Authors sudden departure.”
  
<i>You are taken aback by the insistence of the voice on the other side of the phone.</i> # s You

<i>Are the publishers really taking Mothman’s wellbeing into consideration?</i>

*[“Maybe Mothman needs this break?”]-> needsbreak
*[<i>Agree, his work seems more important.</i>] -> publisheragree
*[“I don’t think I’m qualified to give an opinion on this…”] -> notqualified

=== needsbreak ===
<i>The sound of laughter comes through the other end of the line.</i> # s You # plus 1

“Has he been complaining to you or something? You have <i>got</i> to be kidding me.” # s Publisher

“He does this once every couple of months and returns right as rain once we find him.”

“I assure you, you don’t understand him like <i>we</i> do.”


<i>The phone line crackles on the last few words, filling you with a sense of dread. Suddenly your attempt at standing up for a stranger feels a little embarrassing.</i> # s You

<i>Nobody is allowed to make you feel bad about being kind. You are confident in your decision to help your guest.</i>

-> phoneend

=== publisheragree ===
<i>Begrudgingly, you share this man's sentiment. It wasn’t very professional to run away from work responsibilities. You’ve learnt this the hard way in the past.</i> # s You # minus 1

“Great to see you have some common sense in you. We are working on locating Aubrey and the missing books this very minute. All will be sorted in due time.” # s Publisher

“Can’t believe he’d mock us by booking a stay at a 4.5 star establishment. <i>Honestly.</i>”

<i>Mr Kappa must have forgotten he is speaking on a public line… You cough quietly to bring him back to reality.</i> # s You

<i>He startles, before resuming his suave corporate lingo.</i>

-> phoneend

=== notqualified ===
“That is something you and I can agree on.” # s Publisher # plus 0

<i>The thought of reducing yourself to a simple customer service worker is a little bit depressing.</i> # s You

<i>He is somewhat right though, this is a situation you aren’t exactly prepared to weigh in on…</i>

-> phoneend

=== phoneend ===
“Did you write all that down? Good.” # s Publisher

“Tell him not to get too comfortable. We’ll be in touch.”

<i>They hang up on you and the phone goes back to being silent. You’ll have a lot to catch Mr Mothman up on if he decides to pay your desk a visit later…</i> # s You
-> END




